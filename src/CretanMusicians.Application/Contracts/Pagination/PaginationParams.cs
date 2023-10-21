namespace CretanMusicians.Application.Contracts.Pagination;

public class PaginationParams
{
    private const int MaxItemsPerPage = 3;
    private int _itemsPerPage;

    public int Page { get; set; } = 1;

    public int ItemsPerPage
    {
        get => _itemsPerPage;
        set => _itemsPerPage = value > MaxItemsPerPage ? MaxItemsPerPage : value;
    }
}