using Domain.Read.Repository;
using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Options;

namespace Repository.Read;

public class CountryReadRepository : BaseRepository, ICountryReadRepository
{
    private readonly ElasticsearchClient? client;

    public CountryReadRepository(IOptions<Options> options, ElasticsearchClient client) : base(client)
    {
        this.client = client;
    }
}