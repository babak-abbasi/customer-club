using Domain.Write;
using Domain.Write.Repository;
using Elastic.Clients.Elasticsearch;
using Helper.ExceptionHandling.Types;

namespace Repository.Write;

public abstract class BaseRepository(ElasticsearchClient client) : IBaseRepository
{
    public virtual async Task<T?> GetByIdAsync<T>(string id) where T : Base
    {
        try
        {
            var response = await client.GetAsync<T>(id, x => x.Index(typeof(T).Name.ToLower()));

            if (!response.IsValidResponse)
                throw new ResponsiveException(ExceptionMessage.NoParameter.NotFound);

            return response.Source;
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Read_Failure, ExceptionMessage.WithParameter.ElasticSearch_Read_Failure(exception.Message), exception);
        }
    }
}