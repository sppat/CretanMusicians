using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Pagination;
using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace CretanMusicians.Application.Musicians.GetManyMusicians;

public class GetManyMusiciansQueryHandler : IRequestHandler<GetManyMusiciansQuery, Result<PaginatedResult<MusicianDetailsDto>>>
{
    private readonly IValidator<GetManyMusiciansQuery> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public GetManyMusiciansQueryHandler(IUnitOfWork unitOfWork, IValidator<GetManyMusiciansQuery> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result<PaginatedResult<MusicianDetailsDto>>> Handle(GetManyMusiciansQuery request, CancellationToken cancellationToken)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var validationException = new ValidationException(validationResult.Errors);

            return new Result<PaginatedResult<MusicianDetailsDto>>(validationException);
        }
        
        try
        {
            var result = await _unitOfWork.MusicianRepository.GetManyMusiciansAsync(request.Params);

            return result;
        }
        catch (Exception ex)
        {
            return new Result<PaginatedResult<MusicianDetailsDto>>(ex);
        }
    }
}