using CretanMusicians.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace CretanMusicians.Application.Musicians.GetOneMusician;

public record GetOneMusicianQuery(Guid MusicianId) : IRequest<Result<Musician>>;