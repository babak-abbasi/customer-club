using Service.Read.Repository;
using Elastic.Clients.Elasticsearch;

namespace Repository.Read;

public class ProvinceReadRepository : BaseRepository, IProvinceReadRepository
{
    private readonly ElasticsearchClient? client;

    public ProvinceReadRepository(ElasticsearchClient client) : base(client)
    {
        this.client = client;
    }
}