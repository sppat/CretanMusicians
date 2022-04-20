using AutoMapper;
using CretanMusicians.API.Data;
using CretanMusicians.API.Models.InstrumentDto;
using CretanMusicians.API.Models.OriginDto;

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
        }
    }
}
