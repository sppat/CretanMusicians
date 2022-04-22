using CretanMusicians.API.Data;

namespace CretanMusicians.API.Models.MusicianDto
{
    public class MusicianDto : BaseMusicianDto
    {
        public int Id { get; set; }

        public Origin origin { get; set; }

        public Instrument instrument { get; set; }
    }
}
