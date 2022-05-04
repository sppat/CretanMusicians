using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Models.InstrumentDto
{
    public class BaseInstrumentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
