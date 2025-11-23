using Domain.Read;
using Service.Read.Repository;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Helper.ExceptionHandling.Types;
using Helper.Pagination;

namespace Repository.Read;

public abstract class BaseRepository(ElasticsearchClient client) : IBaseRepository
{
    public virtual async Task<T?> GetByIdAsync<T>(string id) where T : AggreagateRoot
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

    public async Task<ResponsePagination<T>> GetAsync<T, TQuery>(TQuery query) where T : AggreagateRoot where TQuery : RequestPagination
    {
        try
        {
            var shouldQueries = new List<Query>();

            foreach (var prop in query.GetType().GetProperties())
            {
                var val = prop.GetValue(query);
                if (val is string value && !string.IsNullOrWhiteSpace(value))
                {
                    shouldQueries.Add(new MatchQuery
                    {
                        Field = prop.Name.ToLowerInvariant(),
                        Query = value,
                        Fuzziness = "AUTO"  // or "1" or whatever you want
                    });
                }
            }

            var searchRequest = new SearchRequest(typeof(T).Name.ToLower())
            {
                From = (query.PageNumber - 1) * query.PageSize,
                Size = query.PageSize,
                Query = new BoolQuery
                {
                    Should = shouldQueries
                }
            };

            var response = await client.SearchAsync<T>(searchRequest);

            if (!response.IsValidResponse)
                throw new ResponsiveException(ExceptionMessage.NoParameter.NotFound);

            var countResponse = await client.CountAsync<T>(c => c
                .Indices(typeof(T).Name.ToLower())
                .Query(q => q
                    .Bool(b => b
                        .Should(shouldQueries)
                    )
                )
            );

            List<T> result = new();
            foreach (var document in response.Hits)
            {
                var source = document.Source;
                if (source is not null)
                {
                    source.Id = document.Id;
                    result.Add(source);
                }
            }

            var totalCount = countResponse.Count;
            var hasNext = (totalCount - ((query.PageNumber - 1) * query.PageSize) - result.Count) > 0;
            var hasPreviuos = (totalCount - ((query.PageNumber - 1) * query.PageSize) - result.Count) > 0;
            var responsePagination = new ResponsePagination<T>()
            {
                Data = result,
                PageSize = query.PageSize,
                PageNumber = query.PageNumber,
                CurrentSize = result.Count,
                TotalCount = totalCount,
                HasNext = hasNext,
                HasPreviuos = result.Count > 0 && query.PageNumber > 1
            };

            return responsePagination;

        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Read_Failure, ExceptionMessage.WithParameter.ElasticSearch_Read_Failure(exception.Message), exception);
        }
    }
}