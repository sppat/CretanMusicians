using CretanMusicians.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace CretanMusicians.Application.Musicians.CreateMusician
{
    public record CreateMusicianCommand(Guid InstrumentId, string FirstName, string LastName) : IRequest<Result<Musician>>;
}
