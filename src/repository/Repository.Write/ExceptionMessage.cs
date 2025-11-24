namespace Repository.Write;

internal static class ExceptionMessage
{
    internal static class NoParameter
    {
        internal static string NotFound = "Not Found.";
        internal static string Data_Create_Failure = "Data create failure.";
        internal static string Data_Read_Failure = "Data read failure.";
        internal static string Data_Update_Failure = "Data update failure.";
    }
    internal static class WithParameter 
    {
        internal static string ElasticSearch_Create_Failure(string msg) => $"ElasticSearch create failure with message: {msg}";
        internal static string ElasticSearch_Update_Failure(string msg) => $"ElasticSearch update failure with message: {msg}";
        internal static string ElasticSearch_Read_Failure(string msg) => $"ElasticSearch read failure with message: {msg}";
    }
}
