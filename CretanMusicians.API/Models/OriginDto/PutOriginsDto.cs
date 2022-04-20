using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Models.OriginDto
{
    public class PutOriginsDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
