using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebMotors.Application.Web.ViewModels;
using WebMotors.Domain.Entities;

namespace WebMotors.Application.Web.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<AnunciosWebMotors, AnunciosWebMotorsViewModel>().ReverseMap();
            CreateMap<AnunciosWebMotorsViewModel, AnunciosWebMotors>().ReverseMap();

        }
    }
}