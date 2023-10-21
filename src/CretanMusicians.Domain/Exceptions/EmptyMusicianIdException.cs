using System.Net;
using CretanMusicians.Domain.ValidationErrorsMessages;

namespace CretanMusicians.Domain.Exceptions;

public class EmptyMusicianIdException : HttpException
{
    public EmptyMusicianIdException() : base(HttpStatusCode.BadRequest, MusiciansValidateErrors.EmptyMusicianIdError)
    {

    }
}