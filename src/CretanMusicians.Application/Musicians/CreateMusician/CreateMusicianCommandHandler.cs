using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.Entities;
using CretanMusicians.Domain.Exceptions;
using CretanMusicians.Domain.ValueObjects;
using FluentValidation;
using MediatR;

namespace CretanMusicians.Application.Musicians.CreateMusician;

public class CreateMusicianCommandHandler : IRequestHandler<CreateMusicianCommand, Result<MusicianDetailsDto>>
{
    private readonly IValidator<CreateMusicianCommand> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMusicianCommandHandler(IValidator<CreateMusicianCommand> validator, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MusicianDetailsDto>> Handle(CreateMusicianCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationException = new ValidationException(validationResult.Errors);

            return new Result<MusicianDetailsDto>(validationException);
        }

        var (instrumentName, firstName, lastName) = request;

        var musician = Musician.Create(
            id: MusicianId.Create(Guid.NewGuid()),
            firstName: firstName,
            lastName: lastName);

        musician.AddInstrument(new Instrument(instrumentName));

        await _unitOfWork.MusicianRepository.AddAsync(musician);
        await _unitOfWork.SaveChangesAsync();

        return musician.ToDetailsDto();
    }
}