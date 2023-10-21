namespace CretanMusicians.Application.Contracts.Pagination;

public record PaginatedResult<TResult>(IEnumerable<TResult> Items, PaginationMetadata PaginationMetadata);