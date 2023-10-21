namespace CretanMusicians.Domain.ValidationErrorsMessages;

public static class MusiciansValidateErrors
{
    public const string EmptyMusicianIdError = "Musician id must not be empty.";
    public const string EmptyInstrumentName = "Instument name must not be empty.";
    public const string EmptyFirstName = "First name must not be empty.";
    public const string EmptyLastName = "Last name must not be empty.";
    public const string MusicianAlreadyExists = "Musician already exists.";
}