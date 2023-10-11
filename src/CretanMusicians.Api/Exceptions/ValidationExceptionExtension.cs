using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CretanMusicians.Api.Exceptions;

public static class ValidationExceptionExtension
{
    public static ProblemDetails ToProblemDetails(this ValidationException exception)
    {
        return new ProblemDetails();
    }
}