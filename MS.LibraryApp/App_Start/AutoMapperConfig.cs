using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MS.LibraryApp.Models;
using MS.LibraryApp.Models.ViewModels;

namespace MS.LibraryApp
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            var mapper = AutoMapper.Mapper.CreateMap<Book, BookViewModel>();
            mapper.ReverseMap();
        }
    }
}