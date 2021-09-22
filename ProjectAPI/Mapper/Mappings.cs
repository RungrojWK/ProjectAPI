using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models;
using ProjectAPI.Models.Dtos;

namespace ProjectAPI.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TMainPolicy, TMainPolicyDto>().ReverseMap();
        }
    }
}
