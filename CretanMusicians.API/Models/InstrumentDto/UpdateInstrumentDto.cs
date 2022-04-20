using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Models.InstrumentDto
{
    public class UpdateInstrumentDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
