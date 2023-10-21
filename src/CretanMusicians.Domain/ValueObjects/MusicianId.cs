using CretanMusicians.Domain.Exceptions;

namespace CretanMusicians.Domain.ValueObjects;

public record MusicianId
{
    public Guid Value { get; }

    private MusicianId(Guid value) => Value = value;
    
    private MusicianId() {}

    public static MusicianId Create(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyMusicianIdException();
        }

        return new MusicianId(value);
    }
    
    public static implicit operator Guid(MusicianId id) => id.Value;
    public static implicit operator MusicianId(Guid id) => new(id);
}