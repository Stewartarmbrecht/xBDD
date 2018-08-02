using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using xBDD.Shared;
using xBDD.TestRun.Services.Models.Data;
using xBDD.TestRun.Services.Models.Responses;
using xBDD.TestRun.Services.Models.Results;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace xBDD.TestRun.Services.Repositories
{
    public interface ITestRunRepository
    {
        Task<string> AddTestRunAsync(TestRunDocument textObject);
        Task<DeleteTestRunResult> DeleteTestRunAsync(string textId, string userId);
        Task UpdateTestRunAsync(TestRunDocument textDocument);
        Task<TestRunDocument> GetTestRunAsync(string textId, string userId);
        Task<IList<TestRunSummary>> ListTestRunsAsync(string userId);
    }

    public class TestRunRepository : ITestRunRepository
    {
        private static readonly string EndpointUrl = Environment.GetEnvironmentVariable("CosmosDBAccountEndpointUrl");
        private static readonly string AccountKey = Environment.GetEnvironmentVariable("CosmosDBAccountKey");
        private static readonly string DatabaseName = Environment.GetEnvironmentVariable("DatabaseName");
        private static readonly string CollectionName = Environment.GetEnvironmentVariable("CollectionName");
        private static readonly DocumentClient DocumentClient = new DocumentClient(new Uri(EndpointUrl), AccountKey);
        
        private const int MaximumTestRunPreviewLength = 100;

        public async Task<string> AddTestRunAsync(TestRunDocument textDocument)
        {
            var documentUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);
            Document doc = await DocumentClient.CreateDocumentAsync(documentUri, textDocument);
            return doc.Id;
        }

        public async Task<DeleteTestRunResult> DeleteTestRunAsync(string textId, string userId)
        {
            var documentUri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, textId);
            try
            {
                await DocumentClient.DeleteDocumentAsync(documentUri, new RequestOptions { PartitionKey = new PartitionKey(userId)});
                return DeleteTestRunResult.Success;
            }
            catch (DocumentClientException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // we return the NotFound result to indicate the document was not found
                return DeleteTestRunResult.NotFound;
            }
        }

        public Task UpdateTestRunAsync(TestRunDocument textDocument)
        {
            var documentUri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, textDocument.Id);
            return DocumentClient.ReplaceDocumentAsync(documentUri, textDocument);
        }
        
        public async Task<TestRunDocument> GetTestRunAsync(string textId, string userId)
        {
            var documentUri = UriFactory.CreateDocumentUri(DatabaseName, CollectionName, textId);
            try
            {
                var documentResponse = await DocumentClient.ReadDocumentAsync<TestRunDocument>(documentUri, new RequestOptions { PartitionKey = new PartitionKey(userId) });
                return documentResponse.Document;
            }
            catch (DocumentClientException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // we return null to indicate the document was not found
                return null;
            }
        }

        public async Task<IList<TestRunSummary>> ListTestRunsAsync(string userId)
        {
            var documentUri = UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName);

            // create a query to just get the document ids
            var query = DocumentClient
                .CreateDocumentQuery<TestRunDocument>(documentUri)
                .Where(d => d.UserId == userId)
                .Select(d => new TestRunSummary { Id = d.Id, Preview = d.TestRun } )
                .AsDocumentQuery();
            
            // iterate until we have all of the ids
            var list = new List<TestRunSummary>();
            while (query.HasMoreResults)
            {
                var ids = await query.ExecuteNextAsync<TestRunSummary>();
                list.AddRange(ids.Select(d => new TestRunSummary { Id = d.Id, Preview = d.Preview.Truncate(MaximumTestRunPreviewLength) }));
            }
            return list;
        }
    }
}
