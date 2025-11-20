using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Domain.Write.Entities;
using Domain.Repository;
using Microsoft.Extensions.Options;

namespace Repository.Write;

public class CountryRepository : ICountryRepository
{
    private readonly ElasticsearchClient? client;

    public CountryRepository(ElasticsearchClient client)
    {
        this.client = client;
    }

    public async Task<string> AddCountryAsync(string name, string code, decimal order)
    {
        if(client == null)
            throw new Exception($"ElasticSearch connection failure while writing");

        string id = string.Empty;
        try
        {
            var country = new Country(code, name, order);

            var response = await client.IndexAsync(country, x => x.Index("country"));

            if (response.IsValidResponse) 
                id = response.Id;

            return id;
        }
        catch (Exception exception)
        {
            throw new Exception($"ElasticSearch write failure: {exception.Message}");
        }
    }
}
