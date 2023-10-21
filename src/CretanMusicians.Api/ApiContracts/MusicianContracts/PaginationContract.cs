using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.Api.ApiContracts.MusicianContracts;

public record PaginationContract
{
    [Required]
    public int Page { get; init; }
    [Required]
    public int ItemsPerPage { get; init; }
}