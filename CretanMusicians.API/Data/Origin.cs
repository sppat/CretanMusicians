using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Data
{
    public class Origin
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<Musician> Musicians { get; set; }
    }
}