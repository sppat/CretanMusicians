using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Models.OriginDto
{
    public class BaseOriginDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
