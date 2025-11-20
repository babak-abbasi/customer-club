namespace Helper.CustomException;

public class ResponsiveException : CustomException
{
    public ResponsiveException(string message) => Message = message;
}