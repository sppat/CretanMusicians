using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Application.Contracts.Pagination;
using CretanMusicians.Domain.Exceptions;
using MediatR;

namespace CretanMusicians.Application.Musicians.GetManyMusicians;

public record GetManyMusiciansQuery(PaginationParams Params) : IRequest<Result<PaginatedResult<MusicianDetailsDto>>>;