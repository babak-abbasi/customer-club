using Domain.Repository;
using Domain.Write.Entities;
using Elastic.Clients.Elasticsearch;
using Helper.ExceptionHandling.Types;

namespace Repository.Write;

public class CountryRepository(ElasticsearchClient client) : ICountryRepository
{
    public async Task<string> AddCountryAsync(string name, string code, decimal order)
    {
        try
        {
            string id = string.Empty;
            var country = new Country(code, name, order);

            var response = await client.IndexAsync(country, x => x.Index("country"));

            if (!response.IsValidResponse)
                throw new LoggableException(ExceptionMessage.NoParameter.Data_Write_Failure, ExceptionMessage.WithParameter.ElasticSearch_Write_Failure(response?.DebugInformation));

            return response.Id;
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Write_Failure, ExceptionMessage.WithParameter.ElasticSearch_Write_Failure(exception.Message), exception);
        }
    }
}
