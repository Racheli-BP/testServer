using AutoMapper;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonModel, Person>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.YearOfBirth, opt => opt.MapFrom(src => DateTime.Now.Year - src.age))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src=>0))
                .ReverseMap();
        }
    }

}
