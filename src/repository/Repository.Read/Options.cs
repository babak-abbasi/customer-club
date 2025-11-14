namespace Repository.Read;

public class Options
{
    public ElasticSearch ElasticSearch { get; set; }
}

public class ElasticSearch
{
    public string Url { get; set; }
    public string FingerPrint { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}