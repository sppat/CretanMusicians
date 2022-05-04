using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Contracts
{
    public interface IExtendedMusicianDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        int OriginId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        int InstrumentId { get; set; }
    }
}
