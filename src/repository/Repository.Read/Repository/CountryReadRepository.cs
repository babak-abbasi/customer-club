using Domain.Read.Repository;
using Elastic.Clients.Elasticsearch;

namespace Repository.Read;

public class CountryReadRepository : BaseRepository, ICountryReadRepository
{
    private readonly ElasticsearchClient? client;

    public CountryReadRepository(ElasticsearchClient client) : base(client)
    {
        this.client = client;
    }
}