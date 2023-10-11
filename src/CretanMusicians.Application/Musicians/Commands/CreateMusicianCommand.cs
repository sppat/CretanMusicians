namespace CretanMusicians.Application.Musicians.Commands
{
    public record CreateMusicianCommand(Guid InstrumentId, string FirstName, string LastName);
}
