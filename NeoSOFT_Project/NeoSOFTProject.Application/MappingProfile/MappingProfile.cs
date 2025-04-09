using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NeoSOFTProject.Application.DTOs;
using NeoSOFTProject.Domain.Entities;

namespace NeoSOFTProject.Application.MappingProfile
{
    class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetAllBooksDto>().ReverseMap();
            CreateMap<Book, AddBooksDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
