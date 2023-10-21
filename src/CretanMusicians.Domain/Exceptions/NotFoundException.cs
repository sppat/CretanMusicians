using System.Net;

namespace CretanMusicians.Domain.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException(string entityName) : base(HttpStatusCode.NotFound, $"{entityName} not found.")
    {
    }
}