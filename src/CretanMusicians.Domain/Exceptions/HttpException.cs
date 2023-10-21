using System.Net;

namespace CretanMusicians.Domain.Exceptions;

public abstract class HttpException : Exception
{
    public HttpStatusCode StatusCode { get; init; }
    public string ErrorMessage { get; init; }

    public HttpException(HttpStatusCode statusCode, string errorMessage)
    {
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }
}