namespace Helper.ExceptionHandling.Types;

public abstract class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }

    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
    }

    internal ExceptionType ExceptionType { get; set; } = ExceptionType.Responsive;
}
