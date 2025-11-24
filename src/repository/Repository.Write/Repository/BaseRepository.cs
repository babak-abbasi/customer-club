using Domain.Write;
using Domain.Write.Repository;
using Elastic.Clients.Elasticsearch;
using Helper.ExceptionHandling.Types;

namespace Repository.Write;

public abstract class BaseRepository(ElasticsearchClient client) : IBaseRepository
{
    public virtual async Task<string> AddAsync<T>(T input) where T : AggregateRoot
    {
        try
        {
            string id = string.Empty;

            var response = await client.IndexAsync(input, x => x.Index(nameof(T).ToLower()));

            if (!response.IsValidResponse)
                throw new LoggableException(ExceptionMessage.NoParameter.Data_Create_Failure, ExceptionMessage.WithParameter.ElasticSearch_Create_Failure(response?.DebugInformation));

            return response.Id;
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Create_Failure, ExceptionMessage.WithParameter.ElasticSearch_Create_Failure(exception.Message), exception);
        }
    }

    public virtual async Task<T?> GetByIdAsync<T>(string id) where T : AggregateRoot
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

    public virtual async Task UpdateAsync<T>(string id, T entity) where T : AggregateRoot
    {
        try
        {
            var response = await client.UpdateAsync<T, T>(typeof(T).Name.ToLower(), id, u => u.Doc(entity));

            if (!response.IsValidResponse)
                throw new LoggableException(ExceptionMessage.NoParameter.Data_Update_Failure, ExceptionMessage.WithParameter.ElasticSearch_Update_Failure(response?.DebugInformation));
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Update_Failure, ExceptionMessage.WithParameter.ElasticSearch_Update_Failure(exception.Message), exception);
        }
    }
}