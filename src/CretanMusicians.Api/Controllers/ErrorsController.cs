using System.Net;
using CretanMusicians.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CretanMusicians.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

        return exception?.Error is HttpException httpException
            ? Problem(statusCode: (int)httpException.StatusCode, title: httpException.ErrorMessage)
            : Problem(statusCode: (int)HttpStatusCode.InternalServerError, title: "Oops! Something went wrong.");
    }
}