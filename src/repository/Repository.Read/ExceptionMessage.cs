namespace Repository.Read;

internal static class ExceptionMessage
{
    internal static class NoParameter
    {
        internal static string NotFound = "Not Found.";
        internal static string Data_Read_Failure = "Data read failure.";
    }
    internal static class WithParameter 
    {
        internal static string ElasticSearch_Read_Failure(string msg) => $"ElasticSearch read failure with message: {msg}";
    }
}
