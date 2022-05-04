using AutoMapper;
using CretanMusicians.API.Data;
using CretanMusicians.API.Models.InstrumentDto;
using CretanMusicians.API.Models.MusicianDto;
using CretanMusicians.API.Models.OriginDto;
using CretanMusicians.API.Models.Users;

namespace CretanMusicians.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // Origin Map
            CreateMap<Origin, OriginDto>().ReverseMap();
            CreateMap<Origin, GetOriginsDto>().ReverseMap();
            CreateMap<Origin, PostOriginsDto>().ReverseMap();
            CreateMap<Origin, PutOriginsDto>().ReverseMap();

            // Instrument Map
            CreateMap<Instrument, GetInstrumentsDto>().ReverseMap();
            CreateMap<Instrument, InstrumentDto>().ReverseMap();
            CreateMap<Instrument, UpdateInstrumentDto>().ReverseMap();

            // Musician Map
            CreateMap<Musician, MusicianDto>()
                .ForMember(dest =>
                    dest.Origin,
                    opt => opt.MapFrom(src => src.Origin.Name))
                .ForMember(dest =>
                    dest.Instrument,
                    opt => opt.MapFrom(src => src.Instrument.Name))
                .ReverseMap();
            CreateMap<Musician, CreateMusicianDto>().ReverseMap();
            CreateMap<Musician, UpdateMusicianDto>().ReverseMap();

            // Authentication Map
            CreateMap<ApiUser, ApiUserDto>().ReverseMap();
        }
    }
}
