using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs;
using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Web.ViewModels;

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


        }
    } 
       
}
