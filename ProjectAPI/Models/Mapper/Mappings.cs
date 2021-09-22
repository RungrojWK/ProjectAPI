using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Models.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
