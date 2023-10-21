using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.Entities;
using CretanMusicians.Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace CretanMusicians.Application.Musicians.GetOneMusician;

public class GetOneMusicianQueryHandler : IRequestHandler<GetOneMusicianQuery, Result<MusicianDetailsDto>>
{
    private readonly GetOneMusicianValidator _validator;
    private readonly IMusicianRepository _musicianRepository;

    public GetOneMusicianQueryHandler(GetOneMusicianValidator validator, IMusicianRepository musicianRepository)
    {
        _validator = validator;
        _musicianRepository = musicianRepository;
    }

    public async Task<Result<MusicianDetailsDto>> Handle(GetOneMusicianQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var validationException = new ValidationException(validationResult.Errors);

            return new Result<MusicianDetailsDto>(validationException);
        }
        
        var musician = await _musicianRepository.GetOneByIdAsync(request.MusicianId);

        if (musician is not null) return musician.ToDetailsDto();
        
        var notFoundException = new NotFoundException(nameof(Musician));

        return new Result<MusicianDetailsDto>(notFoundException);

    }
}