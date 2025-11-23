using Domain.Repository;
using Domain.Write.Entities;
using Elastic.Clients.Elasticsearch;
using Helper.ExceptionHandling.Types;

namespace Repository.Write;

public class ProvinceRepository(ElasticsearchClient client) : IProvinceRepository
{
    public async Task<string> AddProvinceAsync(string name, string code, decimal order, string countryId)
    {
        try
        {
            string id = string.Empty;
            var province = new Province(code, name, order, countryId);

            var response = await client.IndexAsync(province, x => x.Index(nameof(Province).ToLower()));

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
