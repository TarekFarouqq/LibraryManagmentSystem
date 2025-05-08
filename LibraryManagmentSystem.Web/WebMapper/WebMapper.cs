using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs.AuthorDTOs;
using LibraryManagmentSystem.BLL.DTOs.BookDTOs;

using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Web.ViewModels.AuthorVMs;
using LibraryManagmentSystem.Web.ViewModels.BookVMs;

namespace LibraryManagmentSystem.BLL.AutoMapper
{
    public class WebMapper : Profile
    {
        public WebMapper()
        {
            //Author Profile 
            CreateMap<ReadAuthorDTO, ReadAuthorViewModel>();

            CreateMap<InsertAuthorViewModel, InsertAuthorDTO>();
            CreateMap<ReadAuthorDTO, UpdateAuthorViewModel>();
            CreateMap<UpdateAuthorViewModel, UpdateAuthorDTO>();


            //Book Profile
            CreateMap<ReadBookDTO, ReadBookViewModel>()
            .ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre.ToString()));

            CreateMap<InsertBookViewModel, InsertBookDTO>();
            CreateMap<ReadBookDTO, UpdateBookViewModel>();
            CreateMap<UpdateBookViewModel, UpdateBookDTO>();


        }
    } 
       
}
