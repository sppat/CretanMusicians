using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Domain.Exceptions;
using MediatR;

namespace CretanMusicians.Application.Musicians.GetOneMusician;

public record GetOneMusicianQuery(Guid MusicianId) : IRequest<Result<MusicianDetailsDto>>;