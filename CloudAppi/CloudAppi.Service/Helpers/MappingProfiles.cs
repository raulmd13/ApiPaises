using AutoMapper;
using CloudAppi.Models;
using CloudAppi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CloudAppi.Service.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<CountryApiDTO, Country>()
                .ForMember(
                dest=> dest.Name,
                opt => opt.MapFrom(src => $"{src.name}")
                )
                .ForMember(
                dest=> dest.Alpha2Code,
                opt => opt.MapFrom(src => $"{src.cca2}")
                )
                .ForMember(
                dest=> dest.Alpha3Code,
                opt => opt.MapFrom(src => $"{src.cca3}")
                )
                .ForMember(
                dest=> dest.Capital,
                opt => opt.MapFrom(src => $"{src.capital.FirstOrDefault()}")
                )
                .ForMember(
                dest=> dest.Region,
                opt => opt.MapFrom(src => $"{src.region}")
                )
                .ForMember(
                dest=> dest.NativeName,
                opt => opt.MapFrom(src => $"{src.name.nativeName.spa.official}")
                );
        }
    }
}
