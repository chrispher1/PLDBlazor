using AutoMapper;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Carrier, CarrierDTO>().ReverseMap();
            CreateMap<ProductType, ProductTypeDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserForRegisterDTO>().ReverseMap();
            CreateMap<Activity, ActivityDTO>().ReverseMap();
            CreateMap<TimeActivityMapping, TimeActivityMappingDTO>().ReverseMap();
            CreateMap<PremiumMode, PremiumModeDTO>().ReverseMap();
            CreateMap<CommissionError, CommissionErrorDTO>().ReverseMap();
            CreateMap<CommissionFinal, CommissionFinalDTO>().ReverseMap();
            CreateMap<CommissionErrorDTO, CommissionFinalDTO>().ReverseMap();
            CreateMap<CommissionError, CommissionDTO>();

        }
    }
}
