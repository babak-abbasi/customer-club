namespace Domain.Write;

internal static class ExceptionMessage
{
    internal static class NoParameter
    {
        internal static string NotFound = "Not Found.";
        internal static string SameCodeExist = "Same code exist.";
        internal static string SameNameExist = "Same name exist.";
    }
    internal static class WithParameter 
    {
        internal static string NotFound(string str) => $"{str} not found.";
    }
}
