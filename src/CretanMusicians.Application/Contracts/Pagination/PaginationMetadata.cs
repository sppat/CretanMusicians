namespace CretanMusicians.Application.Contracts.Pagination;

public class PaginationMetadata
{
    public int CurrentPage { get; private set; }
    public int TotalCount { get; private set; }
    public int TotalPages { get; private set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;

    public PaginationMetadata(int currentPage, int totalCount, int itemsPerPage)
    {
        CurrentPage = currentPage;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)itemsPerPage);
    }
}