using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Domain.Entities.Read;
using Domain.Read.Repository;
using Microsoft.Extensions.Options;

namespace Repository.Read;

public class CountryReadRepository: ICountryReadRepository
{
    private readonly ElasticsearchClient? client;

    public CountryReadRepository(IOptions<Options> options, ElasticsearchClient client)
    {
        this.client = client;
    }

    public async Task<Country?> GetCountryByIdAsync(string id)
    {
        if(client == null)
            throw new Exception($"ElasticSearch connection failure while reading");

        try
        {
            var response = await client.GetAsync<Country>(id, x => x.Index("country"));

            if (!response.IsValidResponse)
                throw new Exception($"Not Found.");

            return new Country()
            {
                Id = id,
                Code = response.Source.Code,
                Name = response.Source.Name,
                CreatedDate = response.Source.CreatedDate,
                ModifiedDate = response.Source.ModifiedDate,
                Order = response.Source.Order
            };
        }
        catch(Exception exception)
        {
            throw new Exception($"ElasticSearch read failure: {exception.Message}");
        }
    }

    public async Task<Country?> GetCountriesAsync()
    {
        if(client == null)
            throw new Exception($"ElasticSearch connection failure while reading");

        try
        {
            var response = await client.GetAsync<Country>(id, x => x.Index("country"));

            if (!response.IsValidResponse)
                throw new Exception($"Not Found.");

            return new Country()
            {
                Id = id,
                Code = response.Source.Code,
                Name = response.Source.Name,
                CreatedDate = response.Source.CreatedDate,
                ModifiedDate = response.Source.ModifiedDate,
                Order = response.Source.Order
            };
        }
        catch(Exception exception)
        {
            throw new Exception($"ElasticSearch read failure: {exception.Message}");
        }
    }
}