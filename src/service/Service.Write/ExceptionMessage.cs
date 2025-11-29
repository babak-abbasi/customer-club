namespace Service.Write;

internal static class ExceptionMessage
{
    internal static class NoParameter
    {
        internal static string NotFound = "Not Found.";
        internal static string Data_Has_Been_Used = "Data has been used.";
    }
    internal static class WithParameter
    {
        internal static string NotFound(string str) => $"{str} not found.";
    }
}
