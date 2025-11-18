using Domain.Read;
using Elastic.Clients.Elasticsearch;

namespace Repository.Read;

public abstract class BaseRepository
{
    private readonly ElasticsearchClient client;

    public BaseRepository(ElasticsearchClient client)
    {
        this.client = client;
    }

    public virtual async Task<T?> GetByIdAsync<T>(string id) where T : Base
    {
        if(client == null)
            throw new Exception($"ElasticSearch connection failure while reading");

        try
        {
            var response = await client.GetAsync<T>(id, x => x.Index(typeof(T).Name.ToLower()));

            if (!response.IsValidResponse)
                throw new Exception($"Not Found.");

            return response.Source;
        }
        catch(Exception exception)
        {
            throw new Exception($"ElasticSearch read failure: {exception.Message}");
        }
    }

    public async Task<List<T>> GetAllAsync<T>() where T : Base
    {
        if (client == null)
            throw new Exception($"ElasticSearch connection failure while reading");

        try
        {
            List<T> result = new();
            var response = await client.SearchAsync<T>(s => s
                .Indices(typeof(T).Name.ToLower()));

            if (!response.IsValidResponse)
                throw new Exception($"Not Found.");

            foreach (var document in response.Hits)
            {
                var source = document.Source;
                source.Id = document.Id;
                result.Add(source);
            }

            return result;

        }
        catch (Exception exception)
        {
            throw new Exception($"ElasticSearch read failure: {exception.Message}");
        }
    }
}