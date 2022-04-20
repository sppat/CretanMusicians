using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CretanMusicians.API.Data
{
    public class Musician
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(OriginId))]
        public int OriginId { get; set; }
        public Origin Origin { get; set; }

        [Required]
        [ForeignKey(nameof(InstrumentId))]
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}
