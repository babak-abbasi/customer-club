using Domain.Read;
using Elastic.Clients.Elasticsearch;
using Helper.CustomException;

namespace Repository.Read;

public abstract class BaseRepository(ElasticsearchClient client)
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
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Read_Failure, ExceptionMessage.WithParameter.ElasticSearch_Read_Failure(exception.Message));
        }
    }

    public async Task<List<T>> GetAllAsync<T>() where T : Base
    {
        try
        {
            List<T> result = new();
            var response = await client.SearchAsync<T>(s => s
                .Indices(typeof(T).Name.ToLower()));

            if (!response.IsValidResponse)
                throw new ResponsiveException(ExceptionMessage.NoParameter.NotFound);

            foreach (var document in response.Hits)
            {
                var source = document.Source;
                if (source is not null)
                {
                    source.Id = document.Id;
                    result.Add(source);
                }
            }

            return result;

        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Read_Failure, ExceptionMessage.WithParameter.ElasticSearch_Read_Failure(exception.Message));
        }
    }
}