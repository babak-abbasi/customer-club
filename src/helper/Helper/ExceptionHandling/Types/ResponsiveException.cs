namespace Helper.ExceptionHandling.Types;

public class ResponsiveException : CustomException
{
    public ResponsiveException(string message) : base(message)
    {
    }

    public ResponsiveException(string message, Exception innerException) : base(message, innerException)
    {
    }
}