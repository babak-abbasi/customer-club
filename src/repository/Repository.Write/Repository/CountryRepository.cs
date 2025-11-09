using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Domain.Entities.Write;
using Domain.Repository;
using Microsoft.Extensions.Options;

namespace Repository.Write;

public class CountryRepository : ICountryRepository
{
    private readonly ElasticsearchClient? client;

    public CountryRepository(IOptions<Options> options)
    {
        try
        {
            var settings = new ElasticsearchClientSettings(new Uri(options.Value.ElasticSearch.Url))
                .CertificateFingerprint(options.Value.ElasticSearch.FingerPrint)
                .Authentication(new BasicAuthentication(options.Value.ElasticSearch.UserName, options.Value.ElasticSearch.Password));

            client = new ElasticsearchClient(settings);
        }
        catch(Exception exception)
        {
            throw new Exception($"ElasticSearch connection failure: {exception.Message}");
        }
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
