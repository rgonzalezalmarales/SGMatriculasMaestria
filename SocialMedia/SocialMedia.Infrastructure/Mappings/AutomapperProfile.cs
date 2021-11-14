using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Posts Mappings
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            //Security Mappings
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
