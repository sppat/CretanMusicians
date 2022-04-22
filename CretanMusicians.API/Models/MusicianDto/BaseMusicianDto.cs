using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Models.MusicianDto
{
    public class BaseMusicianDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int OriginId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int InstrumentId { get; set; }
    }
}
