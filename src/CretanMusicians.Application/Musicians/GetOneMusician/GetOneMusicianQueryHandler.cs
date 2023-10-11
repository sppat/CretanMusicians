using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace CretanMusicians.Application.Musicians.GetOneMusician;

public class GetOneMusicianQueryHandler : IRequestHandler<GetOneMusicianQuery, Result<Musician>>
{
    private readonly GetOneMusicianValidator _validator;
    private readonly IMusicianRepository _musicianRepository;

    public GetOneMusicianQueryHandler(GetOneMusicianValidator validator, IMusicianRepository musicianRepository)
    {
        _validator = validator;
        _musicianRepository = musicianRepository;
    }

    public async Task<Result<Musician>> Handle(GetOneMusicianQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);
        
        if (validationResult.IsValid) return await _musicianRepository.GetOneByIdAsync(request.MusicianId);
        
        var validationException = new ValidationException(validationResult.Errors);

        return new Result<Musician>(validationException);

    }
}