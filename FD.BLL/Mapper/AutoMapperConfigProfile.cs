using AutoMapper;
using FD.BLL.Models.Reference;
using FD.BLL.Models.User;
using FD.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FD.BLL.Mapper
{
    public class AutoMapperConfigProfile :Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<CovidTest, CovidTestModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            
        }
    }
}
