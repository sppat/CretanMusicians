using System.Data;
using CretanMusicians.Domain.ValidationErrorsMessages;
using FluentValidation;

namespace CretanMusicians.Application.Musicians.GetOneMusician;

public sealed class GetOneMusicianValidator : AbstractValidator<GetOneMusicianQuery> 
{
    public GetOneMusicianValidator()
    {
        RuleFor(getOneMusicianQuery => getOneMusicianQuery.MusicianId)
            .Must(musicianId => musicianId != Guid.Empty)
            .WithMessage(MusiciansValidateErrors.EmptyMusicianIdError);
    }
}