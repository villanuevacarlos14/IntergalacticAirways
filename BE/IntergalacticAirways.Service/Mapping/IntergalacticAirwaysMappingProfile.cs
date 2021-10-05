using AutoMapper;
using IntergalacticAirways.DTO;
using IntergalacticeAirways.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticAirways.Service.Mapping
{
    public class IntergalacticAirwaysMappingProfile : Profile
    {
        public IntergalacticAirwaysMappingProfile() 
        {
            CreateMap<Starship, StarshipDTO>().ReverseMap();
        }
    }
}
