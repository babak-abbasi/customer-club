using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Domain.Entities.Write;
using Domain.Repository;

namespace Repository.Write;

public class CountryRepository : ICountryRepository
{
    private readonly ElasticsearchClient? client;

    public CountryRepository()
    {
        try
        {
            var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
                .CertificateFingerprint("43:0B:E0:A1:FB:95:DC:46:F3:BA:11:10:DC:E3:1D:63:59:C8:88:6A:E3:39:4C:32:6D:B1:A8:1A:36:41:96:3D")
                .Authentication(new BasicAuthentication("elastic", "y8YzOqL9ADKQqYFnwcBP"));

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
