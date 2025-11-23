using Elastic.Clients.Elasticsearch;
using Service.Read.Repository;

namespace Repository.Read;

public class CountryReadRepository : BaseRepository, ICountryReadRepository
{
    private readonly ElasticsearchClient? client;

    public CountryReadRepository(ElasticsearchClient client) : base(client)
    {
        this.client = client;
    }
}