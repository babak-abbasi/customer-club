using Domain.Repository;
using Domain.Write.Entities;
using Elastic.Clients.Elasticsearch;
using Helper.ExceptionHandling.Types;

namespace Repository.Write;

public class CountryRepository(ElasticsearchClient client) : BaseRepository(client), ICountryRepository
{

}
