using System.Threading.Tasks;
using xBDD.Shared;
using xBDD.Shared.EventSchemas.TestRun;
using xBDD.TestRun.Services.Models.Data;
using xBDD.TestRun.Services.Models.Responses;
using xBDD.TestRun.Services.Models.Results;
using xBDD.TestRun.Services.Repositories;

namespace xBDD.TestRun.Services
{
    public interface ITestRunService
    {
        Task<string> AddTestRunAsync(string text, string userId, string categoryId);
        Task<DeleteTestRunResult> DeleteTestRunAsync(string textId, string userId);
        Task<UpdateTestRunResult> UpdateTestRunAsync(string textId, string userId, string text);
        Task<TestRunDetails> GetTestRunAsync(string textId, string userId);
        Task<TestRunSummaries> ListTestRunsAsync(string userId);
    }

    public class TestRunService : ITestRunService
    {
        protected ITestRunRepository TestRunRepository;
        protected IEventGridPublisherService EventGridPublisher;

        private const int MaximumTestRunPreviewLength = 100;

        public TestRunService(ITestRunRepository textRepository, IEventGridPublisherService eventGridPublisher)
        {
            TestRunRepository = textRepository;
            EventGridPublisher = eventGridPublisher;
        }

        public async Task<string> AddTestRunAsync(string text, string userId, string categoryId)
        {
            // create the document in Cosmos DB
            var textDocument = new TestRunDocument
            {
                UserId = userId,
                TestRun = text,
                CategoryId = categoryId
            };
            var textId = await TestRunRepository.AddTestRunAsync(textDocument);
            
            // post a TestRunCreated event to Event Grid
            var eventData = new TestRunCreatedEventData
            {
                Preview = text.Truncate(MaximumTestRunPreviewLength),
                Category = categoryId
            };
            var subject = $"{userId}/{textId}";
            await EventGridPublisher.PostEventGridEventAsync(EventTypes.TestRun.TestRunCreated, subject, eventData);
            
            return textId;
        }

        public async Task<DeleteTestRunResult> DeleteTestRunAsync(string textId, string userId)
        {
            // delete the document from Cosmos DB
            var result = await TestRunRepository.DeleteTestRunAsync(textId, userId);
            if (result == DeleteTestRunResult.NotFound)
            {
                return DeleteTestRunResult.NotFound;
            }

            // post a TestRunDeleted event to Event Grid
            var subject = $"{userId}/{textId}";
            await EventGridPublisher.PostEventGridEventAsync(EventTypes.TestRun.TestRunDeleted, subject, new TestRunDeletedEventData());

            return DeleteTestRunResult.Success;
        }

        public async Task<UpdateTestRunResult> UpdateTestRunAsync(string textId, string userId, string text)
        {
            // get the current version of the document from Cosmos DB
            var textDocument = await TestRunRepository.GetTestRunAsync(textId, userId);
            if (textDocument == null)
            {
                return UpdateTestRunResult.NotFound;
            }

            // update the document with the new text
            textDocument.TestRun = text;
            await TestRunRepository.UpdateTestRunAsync(textDocument);

            // post a TestRunUpdated event to Event Grid
            var eventData = new TestRunUpdatedEventData
            {
                Preview = text.Truncate(MaximumTestRunPreviewLength)
            };
            var subject = $"{userId}/{textId}";
            await EventGridPublisher.PostEventGridEventAsync(EventTypes.TestRun.TestRunUpdated, subject, eventData);

            return UpdateTestRunResult.Success;
        }

        public async Task<TestRunDetails> GetTestRunAsync(string textId, string userId)
        {
            var textDocument = await TestRunRepository.GetTestRunAsync(textId, userId);
            if (textDocument == null)
            {
                return null;
            }

            return new TestRunDetails
            {
                Id = textDocument.Id,
                TestRun = textDocument.TestRun
            };
        }

        public async Task<TestRunSummaries> ListTestRunsAsync(string userId)
        {
            var blobs = await TestRunRepository.ListTestRunsAsync(userId);

            var summaries = new TestRunSummaries();
            summaries.AddRange(blobs);
            return summaries;
        }
    }
}
