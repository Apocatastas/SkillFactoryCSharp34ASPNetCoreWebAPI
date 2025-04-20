using AutoMapper;
using HomeApi.Configuration;
using HomeAPI.Contracts.Home;

namespace HomeAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m => m.AddressInfo,
                    opt => opt.MapFrom(src => src.Address));
        }
    }
}
