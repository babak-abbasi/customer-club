namespace Service.Write;

public class Options
{
    public ElasticSearch ElasticSearch { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class ElasticSearch
{
    public string Url { get; set; }
    public string FingerPrint { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class ConnectionStrings 
{ 
    public string WriteDb { get; set; }
}