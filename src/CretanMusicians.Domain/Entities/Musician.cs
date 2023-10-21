using CretanMusicians.Domain.ValueObjects;

namespace CretanMusicians.Domain.Entities;

public class Musician
{
    public MusicianId Id { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public HashSet<Instrument> Instruments { get; init; } = new();

    private Musician() {}

    private Musician(MusicianId id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public void AddInstrument(Instrument instrument) => Instruments.Add(instrument);

    public static Musician Create(MusicianId id, string firstName, string lastName)
        => new(id, firstName, lastName);
}