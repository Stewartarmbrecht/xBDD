using System.Linq;
using System.Threading.Tasks;
using xBDD.Shared;
using xBDD.Shared.EventSchemas.TestRun;
using xBDD.TestRun.Services.Models.Data;
using xBDD.TestRun.Services.Models.Results;
using Moq;
using Xunit;

namespace xBDD.TestRun.Services.Tests
{
    public class TestRunServiceTests
    {
        #region AddTestRun Tests
        [Fact]
        public async Task AddTestRun_ReturnsDocumentId()
        {
            // arrange
            var service = new TestRunService(new FakeTestRunRepository(), new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.AddTestRunAsync("text", "fakeuserid", "categoryid");

            // assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task AddTestRun_AddsDocumentToRepository()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            await service.AddTestRunAsync("text", "fakeuserid", "categoryid");

            // assert
            Assert.Contains(fakeTestRunRepository.TestRunDocuments, d => d.TestRun == "text" && d.CategoryId == "categoryid" && d.UserId == "fakeuserid" );
        }

        [Fact]
        public async Task AddTestRun_PublishesTestRunCreatedEventToEventGrid()
        {
            // arrange
            var mockEventGridPublisherService = new Mock<IEventGridPublisherService>();
            var service = new TestRunService(new FakeTestRunRepository(), mockEventGridPublisherService.Object);

            // act
            var textId = await service.AddTestRunAsync("text", "fakeuserid", "fakecategory");

            // assert
            mockEventGridPublisherService.Verify(m => 
                m.PostEventGridEventAsync(EventTypes.TestRun.TestRunCreated, $"fakeuserid/{textId}", It.Is<TestRunCreatedEventData>(d => d.Preview == "text" && d.Category == "fakecategory")),
                Times.Once);
        }
        #endregion

        #region DeleteTestRun Tests
        [Fact]
        public async Task DeleteTestRun_ReturnsSuccess()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.DeleteTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.Equal(DeleteTestRunResult.Success, result);
        }

        [Fact]
        public async Task DeleteTestRun_DeletesDocumentFromRepository()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            await service.DeleteTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.Empty(fakeTestRunRepository.TestRunDocuments);
        }

        [Fact]
        public async Task DeleteTestRun_PublishesTestRunDeletedEventToEventGrid()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid" });
            var mockEventGridPublisherService = new Mock<IEventGridPublisherService>();
            var service = new TestRunService(fakeTestRunRepository, mockEventGridPublisherService.Object);

            // act
            await service.DeleteTestRunAsync("fakeid", "fakeuserid");

            // assert
            mockEventGridPublisherService.Verify(m => 
                    m.PostEventGridEventAsync(EventTypes.TestRun.TestRunDeleted, "fakeuserid/fakeid", It.IsAny<TestRunDeletedEventData>()),
                Times.Once);
        }

        [Fact]
        public async Task DeleteTestRun_InvalidTestRunId_ReturnsNotFound()
        {
            // arrange
            var service = new TestRunService(new FakeTestRunRepository(), new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.DeleteTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.Equal(DeleteTestRunResult.NotFound, result);
        }

        [Fact]
        public async Task DeleteTestRun_IncorrectUserId_ReturnsSuccess()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid2" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.DeleteTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.Equal(DeleteTestRunResult.NotFound, result);
        }
        #endregion

        #region UpdateTestRun Tests
        [Fact]
        public async Task UpdateTestRun_ReturnsSuccess()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.UpdateTestRunAsync("fakeid", "fakeuserid", "newtext");

            // assert
            Assert.Equal(UpdateTestRunResult.Success, result);
        }

        [Fact]
        public async Task UpdateTestRun_UpdatesDocumentInRepository()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", TestRun = "oldtext", CategoryId = "categoryid" , UserId = "fakeuserid" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);
            
            // act
            await service.UpdateTestRunAsync("fakeid", "fakeuserid", "newtext");

            // assert
            Assert.Equal("newtext", fakeTestRunRepository.TestRunDocuments.Single().TestRun);
        }

        [Fact]
        public async Task UpdateTestRun_PublishesTestRunUpdatedEventToEventGrid()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid" });
            var mockEventGridPublisherService = new Mock<IEventGridPublisherService>();
            var service = new TestRunService(fakeTestRunRepository, mockEventGridPublisherService.Object);

            // act
            await service.UpdateTestRunAsync("fakeid", "fakeuserid", "newtext");

            // assert
            mockEventGridPublisherService.Verify(m => 
                    m.PostEventGridEventAsync(EventTypes.TestRun.TestRunUpdated, "fakeuserid/fakeid", It.Is<TestRunUpdatedEventData>(d => d.Preview == "newtext")),
                Times.Once);
        }

        [Fact]
        public async Task UpdateTestRun_InvalidTestRunId_ReturnsNotFound()
        {
            // arrange
            var service = new TestRunService(new FakeTestRunRepository(), new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.UpdateTestRunAsync("fakeid", "fakeuserid", "newtext");

            // assert
            Assert.Equal(UpdateTestRunResult.NotFound, result);
        }

        [Fact]
        public async Task UpdateTestRun_IncorrectUserId_ReturnsSuccess()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", UserId = "fakeuserid2" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.UpdateTestRunAsync("fakeid", "fakeuserid", "newtext");

            // assert
            Assert.Equal(UpdateTestRunResult.NotFound, result);
        }
        #endregion

        #region GetTestRun Tests
        [Fact]
        public async Task GetTestRun_ReturnsCorrectTestRun()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", TestRun = "faketext", CategoryId = "fakecategoryid", UserId = "fakeuserid" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.GetTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.NotNull(result);
            Assert.Equal("fakeid", result.Id);
            Assert.Equal("faketext", result.TestRun);
        }

        [Fact]
        public async Task GetTestRun_InvalidTestRunId_ReturnsNull()
        {
            // arrange
            var service = new TestRunService(new FakeTestRunRepository(), new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.GetTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetTestRun_IncorrectUserId_ReturnsNull()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid", TestRun = "faketext", CategoryId = "fakecategoryid", UserId = "fakeuserid2" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.GetTestRunAsync("fakeid", "fakeuserid");

            // assert
            Assert.Null(result);
        }
        #endregion
        
        #region ListTestRuns Tests
        [Fact]
        public async Task ListTestRuns_ReturnsIds()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid1", UserId = "fakeuserid", TestRun = "faketext1" });
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid2", UserId = "fakeuserid", TestRun = "faketext2" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.ListTestRunsAsync("fakeuserid");

            // assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Id == "fakeid1" && s.Preview == "faketext1");
            Assert.Contains(result, s => s.Id == "fakeid2" && s.Preview == "faketext2");
        }

        [Fact]
        public async Task ListTestRuns_DoesNotReturnsIdsForAnotherUser()
        {
            // arrange
            var fakeTestRunRepository = new FakeTestRunRepository();
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid1", UserId = "fakeuserid" });
            fakeTestRunRepository.TestRunDocuments.Add(new TestRunDocument { Id = "fakeid2", UserId = "fakeuserid2" });
            var service = new TestRunService(fakeTestRunRepository, new Mock<IEventGridPublisherService>().Object);

            // act
            var result = await service.ListTestRunsAsync("fakeuserid");

            // assert
            Assert.Single(result);
            Assert.Equal("fakeid1", result.Single().Id);
        }
        #endregion
    }
}
