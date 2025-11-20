namespace Repository.Write;

internal static class ExceptionMessage
{
    internal static class NoParameter
    {
        internal static string NotFound = "Not Found.";
        internal static string Data_Write_Failure = "Data write failure.";
    }
    internal static class WithParameter 
    {
        internal static string ElasticSearch_Write_Failure(string msg) => $"ElasticSearch write failure with message: {msg}";
    }
}
