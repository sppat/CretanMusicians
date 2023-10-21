using CretanMusicians.Application.Contracts.Dto.MusicianDto;
using CretanMusicians.Domain.Exceptions;
using MediatR;

namespace CretanMusicians.Application.Musicians.CreateMusician
{
    public record CreateMusicianCommand(string InstrumentName, string FirstName, string LastName) : IRequest<Result<MusicianDetailsDto>>;
}
