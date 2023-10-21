using CretanMusicians.Application.Contracts.Dto.InstrumentDto;

namespace CretanMusicians.Application.Contracts.Dto.MusicianDto;

public record MusicianDetailsDto(
    Guid Id,
    string FirstName,
    string LastName,
    IEnumerable<string> Instruments);