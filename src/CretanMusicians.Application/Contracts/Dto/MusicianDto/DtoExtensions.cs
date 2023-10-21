using CretanMusicians.Application.Contracts.Dto.InstrumentDto;
using CretanMusicians.Domain.Entities;

namespace CretanMusicians.Application.Contracts.Dto.MusicianDto;

public static class DtoExtensions
{
    public static MusicianDetailsDto ToDetailsDto(this Musician musician)
        => new(
            Id: musician.Id,
            FirstName: musician.FirstName,
            LastName: musician.LastName,
            Instruments: musician.Instruments.Select(i => i.Name));
}