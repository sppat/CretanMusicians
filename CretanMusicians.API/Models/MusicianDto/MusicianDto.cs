namespace CretanMusicians.API.Models.MusicianDto
{
    public class MusicianDto : BaseMusicianDto
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Instrument { get; set; }
    }
}
