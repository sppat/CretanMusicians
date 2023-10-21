using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.ValidationErrorsMessages;
using FluentValidation;

namespace CretanMusicians.Application.Musicians.CreateMusician;

public class CreateMusicianValidator : AbstractValidator<CreateMusicianCommand>
{
    public CreateMusicianValidator(IMusicianRepository musicianRepository)
    {
        RuleFor(command => command.InstrumentName)
            .Must(instrumentName => instrumentName is not null)
            .Must(instrumentName => instrumentName != string.Empty)
            .WithMessage(MusiciansValidateErrors.EmptyInstrumentName);

        RuleFor(command => command.FirstName)
            .Must(firstName => firstName is not null)
            .Must(firstName => firstName != string.Empty)
            .WithMessage(MusiciansValidateErrors.EmptyFirstName);

        RuleFor(command => command.LastName)
            .Must(lastName => lastName is not null)
            .Must(lastName => lastName != string.Empty)
            .WithMessage(MusiciansValidateErrors.EmptyLastName);

        RuleFor(command => new { command.FirstName, command.LastName })
            .MustAsync(async (fullName, cancellationToken) =>
            {
                var musicianExists =
                    await musicianRepository.MusicianFullNameExistsAsync(
                        firstName: fullName.FirstName, 
                        lastName: fullName.LastName);

                return !musicianExists;
            })
            .WithMessage(MusiciansValidateErrors.MusicianAlreadyExists);
    }
}