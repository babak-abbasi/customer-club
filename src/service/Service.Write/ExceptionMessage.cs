namespace Service.Write;

internal static class ExceptionMessage
{
    internal static class NoParameter
    {
        internal static string NotFound = "Not Found.";
    }
    internal static class WithParameter
    {
        internal static string NotFound(string str) => $"{str} not found.";
    }
}
