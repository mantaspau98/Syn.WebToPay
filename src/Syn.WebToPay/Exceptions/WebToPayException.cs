namespace Syn.WebToPay.Exceptions;

public class WebToPayException : Exception
{
    public WebToPayException()
    {
    }
    
    public WebToPayException(string message) : base(message)
    {
    }
    
    public WebToPayException(string message, Exception inner) : base(message, inner)
    {
    }
}