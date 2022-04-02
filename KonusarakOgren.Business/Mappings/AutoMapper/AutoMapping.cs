﻿using AutoMapper;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.RequestModels;
using KonusarakOgren.Entities.ResponseModels;
using System;

namespace KonusarakOgren.Business.Mappings.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AddUserRequestModel, User>();
            CreateMap<User, UserResponseModel>();

            CreateMap<TopicFromWebResponseModel, Topic>();
            CreateMap<Topic, TopicFromWebResponseModel>();

            CreateMap<AddQuestionRequestModel, Question>();

            CreateMap<AddAnswerRequestModel, Answer>();
        }
    }
}