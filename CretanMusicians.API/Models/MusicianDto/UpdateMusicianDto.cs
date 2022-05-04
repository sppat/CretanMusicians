using CretanMusicians.API.Contracts;

namespace CretanMusicians.API.Models.MusicianDto
{
    public class UpdateMusicianDto : BaseMusicianDto, IExtendedMusicianDto
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int InstrumentId { get; set; }
    }
}
