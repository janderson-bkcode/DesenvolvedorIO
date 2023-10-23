using br.com.sharklab.elasticsearch.Config;
using br.com.sharklab.elasticsearch.Models.Generics;
using br.com.sharklab.elasticsearch.Utils;
using Microsoft.Extensions.Options;
using OpenSearch.Client;
using System;
using System.Threading.Tasks;

public class ElasticsearchService : IElasticsearchService
{
    private readonly OpenSearchClient _elasticClient;
    private readonly IOptions<ElasticConfiguration> _elasticOptions;

    public ElasticsearchService(IOptions<ElasticConfiguration> elasticsearchSettings)
    {
        var uri = new Uri(elasticsearchSettings.Value.Uri);
        var connectionSettings = new ConnectionSettings(uri)
            .DefaultIndex(elasticsearchSettings.Value.DefaultIndex)
            .BasicAuthentication(elasticsearchSettings.Value.Username, elasticsearchSettings.Value.Password);
        _elasticClient = new OpenSearchClient(connectionSettings);

        _elasticOptions = elasticsearchSettings;
    }

    public async Task IndexRequestResponse(GenericRequestResponse requestResponse, string indexName)
    {
        indexName = ElasticUtils.AddEnvironmentToIndexNameApi(indexName, _elasticOptions);

        await EnsureIndexExists(indexName);

        var bulkDescriptor = new BulkDescriptor();

        bulkDescriptor
            .Index<GenericRequestResponse>(idx => idx
                .Document(requestResponse)
                .Index(indexName));

        await PerformBulkIndexing<GenericRequestResponse>(bulkDescriptor, indexName);
    }

    public async Task IndexDataToElastic<T>(GenericIndexable<T> indexable, Guid guid) where T : class
    {
        await EnsureIndexExists(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions));

        var bulkDescriptor = new BulkDescriptor();

        try
        {
            if (indexable.Data != null)
            {
                var indexData = new GenericIndexable<T>(indexable.Data);
                indexData.GuidIndex = guid;

                bulkDescriptor.Index<GenericIndexable<T>>(idx => idx
                    .Document(indexData)
                    .Index(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions)));
            }

            if (indexable.DataList is { Count: > 0 })
            {
                foreach (var item in indexable.DataList)
                {
                    var indexData = new GenericIndexable<T>(item);
                    indexData.GuidIndex = guid;

                    bulkDescriptor.Index<GenericIndexable<T>>(idx => idx
                        .Document(indexData)
                        .Index(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions)));
                }
            }
            await PerformBulkIndexing<T>(bulkDescriptor);
        }
        catch (Exception e)
        {
            var indexData = new GenericLog<T>(indexable.Data);
            indexData.Exception = e;
            indexData.GuidIndex = guid;

            bulkDescriptor.Index<GenericLog<T>>(idx => idx
                .Document(indexData)
                .Index(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions)));

            await PerformBulkIndexing<T>(bulkDescriptor);
        }
    }

    public async Task IndexDataWithLogExceptionToElastic<T>(GenericLog<T> indexable, Guid guid, Exception exception = null)
        where T : class
    {
        await EnsureIndexExists(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions));

        var bulkDescriptor = new BulkDescriptor();

        try
        {
            if (indexable.Data != null && exception != null)
            {
                var indexData = new GenericLog<T>(indexable.Data);
                indexData.Exception = exception;
                indexData.GuidIndex = guid;

                bulkDescriptor.Index<GenericLog<T>>(idx => idx
                    .Document(indexData)
                    .Index(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions)));

                await PerformBulkIndexing<T>(bulkDescriptor);
            }

            if (indexable.Data != null && exception == null)
            {
                var indexData = new GenericLog<T>(indexable.Data);
                indexData.GuidIndex = guid;

                bulkDescriptor.Index<GenericLog<T>>(idx => idx
                    .Document(indexData)
                    .Index(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions)));

                await PerformBulkIndexing<T>(bulkDescriptor);
            }
        }
        catch (Exception e)
        {
            var indexData = new GenericLog<T>(indexable.Data);
            indexData.Exception = e;
            indexData.GuidIndex = guid;

            bulkDescriptor.Index<GenericLog<T>>(idx => idx
                .Document(indexData)
                .Index(ElasticUtils.GenerateIndexNameGeneralApplications(_elasticOptions)));

            await PerformBulkIndexing<T>(bulkDescriptor);
        }
    }

    private async Task PerformBulkIndexing<T>(BulkDescriptor bulkDescriptor, string indexName = null) where T : class
    {
        BulkResponse bulkResponse = new BulkResponse();

        try
        {
            bulkResponse = await _elasticClient.BulkAsync(bulkDescriptor);

            if (!bulkResponse.IsValid)
                throw new Exception(bulkResponse.OriginalException.Message, bulkResponse.OriginalException.InnerException);
        }
        catch (Exception e)
        {
            var indexData = new GenericLog<BulkResponse>(bulkResponse);
            indexData.Exception = e;

            if (indexName != null) indexData.IndexName = indexName;

            bulkDescriptor.Index<GenericLog<BulkResponse>>(idx => idx
                .Document(indexData)
                .Index("index-erro-response-opensearch"));

            await PerformBulkIndexing<GenericLog<BulkResponse>>(bulkDescriptor);

            throw;
        }
    }

    private async Task EnsureIndexExists(string indexName)
    {
        if (!(await _elasticClient.Indices.ExistsAsync(indexName.ToLower())).Exists)
            await _elasticClient.Indices.CreateAsync(indexName.ToLower());
    }
}