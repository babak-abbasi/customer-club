using Domain.Repository;
using Elastic.Clients.Elasticsearch;

namespace Repository.Write;

public class ProvinceRepository(ElasticsearchClient client) : BaseRepository(client), IProvinceRepository
{
}
