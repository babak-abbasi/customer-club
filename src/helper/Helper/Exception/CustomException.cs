namespace Helper.CustomException;

public abstract class CustomException : Exception
{
    internal ExceptionType ExceptionType { get; set; } = ExceptionType.Responsive;
    public string Message { get; set; }
}
