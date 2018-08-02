using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xBDD.Shared;
using xBDD.TestRun.Services.Models.Data;
using xBDD.TestRun.Services.Models.Responses;
using xBDD.TestRun.Services.Models.Results;
using xBDD.TestRun.Services.Repositories;

namespace xBDD.TestRun.Services.Tests
{
    public class FakeTestRunRepository : ITestRunRepository
    {
        public readonly IList<TestRunDocument> TestRunDocuments = new List<TestRunDocument>();
        private const int MaximumTestRunPreviewLength = 100;

        public Task<string> AddTestRunAsync(TestRunDocument textDocument)
        {
            if (string.IsNullOrEmpty(textDocument.Id))
            {
                textDocument.Id = Guid.NewGuid().ToString();
            }

            TestRunDocuments.Add(textDocument);
            return Task.FromResult(textDocument.Id);
        }

        public Task<DeleteTestRunResult> DeleteTestRunAsync(string textId, string userId)
        {
            var documentToRemove = TestRunDocuments.SingleOrDefault(d => d.Id == textId && d.UserId == userId);
            if (documentToRemove == null)
            {
                return Task.FromResult(DeleteTestRunResult.NotFound);
            }

            TestRunDocuments.Remove(documentToRemove);
            return Task.FromResult(DeleteTestRunResult.Success);
        }

        public Task UpdateTestRunAsync(TestRunDocument textDocument)
        {
            var documentToUpdate = TestRunDocuments.SingleOrDefault(d => d.Id == textDocument.Id && d.UserId == textDocument.UserId);
            if (documentToUpdate == null)
            {
                throw new InvalidOperationException("UpdateTestRunAsync called for document that does not exist.");
            }
            documentToUpdate.TestRun = textDocument.TestRun;
            documentToUpdate.CategoryId = textDocument.CategoryId;
            return Task.CompletedTask;
        }

        public Task<TestRunDocument> GetTestRunAsync(string textId, string userId)
        {
            var document = TestRunDocuments.SingleOrDefault(d => d.Id == textId && d.UserId == userId);
            return Task.FromResult(document);
        }

        public Task<IList<TestRunSummary>> ListTestRunsAsync(string userId)
        {
            IList<TestRunSummary> list = TestRunDocuments
                .Where(d => d.UserId == userId)
                .Select(d => new TestRunSummary { Id = d.Id, Preview = d.TestRun.Truncate(MaximumTestRunPreviewLength) })
                .ToList();
            return Task.FromResult(list);
        }
    }
}
