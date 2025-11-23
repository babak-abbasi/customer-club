using Domain.Read;

namespace Repository.Read;

internal class BaseElasticsearch<T> where T : AggreagateRoot
{
    internal string Id { get; set; }
    internal T Source { get; set; }
}
