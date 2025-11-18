using Domain.Read;

namespace Repository.Read;

internal class BaseElasticsearch<T> where T : Base
{
    internal string Id { get; set; }
    internal T Source { get; set; }
}
