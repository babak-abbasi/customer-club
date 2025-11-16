using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Domain.Entities.Write;
using Domain.Repository;
using Microsoft.Extensions.Options;

namespace Repository.Write;

public class CountryRepository : ICountryRepository
{
    private readonly ElasticsearchClient? client;

    public CountryRepository(IOptions<Options> options, ElasticsearchClient client)
    {
        this.client = client;
    }

    public async Task<string> AddCountryAsync(string name, string code)
    {
        if(client == null)
            throw new Exception($"ElasticSearch connection failure while writing");

        try
        {
            var country = new Country()
            {
                Code = code,
                Name = name
            };

            var response = await client.IndexAsync(country, x => x.Index("country"));

            if (response.IsValidResponse)
            {
                Console.WriteLine($"Index document with ID {response.Id} succeeded.");

                return response.Id;
            }

            return string.Empty;
        }
        catch(Exception exception)
        {
            throw new Exception($"ElasticSearch write failure: {exception.Message}");
        }
    }
}
