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
        }
    }
}
