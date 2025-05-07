using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.BuisnessMapper
{
     public class BuisnessMapper : Profile
    {
        public BuisnessMapper()
        {
            //Author Profile 
            CreateMap<Author, ReadAuthorDTO>()
                .ForMember(dest => dest.Books,option => option.MapFrom(src => src.Books.Select(b=> b.Title).ToList()));

            CreateMap<InsertAuthorDTO, Author>();
            CreateMap<UpdateAuthorDTO, Author>();

        }
    }

}
