namespace CretanMusicians.Domain.ValidationErrorsMessages;

public static class GetManyMusiciansQueryErrors
{
    public const string EmptyItemsPerPage = "ItemsPerPage parameter cannot be 0";
    public const string EmptyPage = "Page parameter cannot be 0";
}