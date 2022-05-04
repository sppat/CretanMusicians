using CretanMusicians.API.Contracts;

namespace CretanMusicians.API.Models.MusicianDto
{
    public class CreateMusicianDto : BaseMusicianDto, IExtendedMusicianDto
    {
        public int OriginId { get; set; }
        public int InstrumentId { get; set; }
    }
}
