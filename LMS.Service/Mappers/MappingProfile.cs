﻿using AutoMapper;

namespace LMS.Services.Mappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.UserRequestModel, Data.entities.User>().ReverseMap();
            CreateMap<Models.UserResponseModel, Data.entities.User>().ReverseMap();
        }
    }
}
