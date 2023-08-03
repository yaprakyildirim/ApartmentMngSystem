using ApartmentMngSystem.Business.DTOs;
using ApartmentMngSystem.Core.Entities;
using AutoMapper;

namespace ApartmentMngSystem.Business.Mapping
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            this.CreateMap<User, CreatedUserDto>().ReverseMap();
        }
    }
}
