using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.DTOs;
using AutoMapper;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json.Linq;

namespace API.Profiles
{
    public class GoogleMappingProfile : Profile
    {
        public GoogleMappingProfile()
        {
            CreateMap<JObject, GoogleDto>()
                .ForMember(dest => dest.News, opt => opt.MapFrom(src => src["items"].ToObject<IList<GoogleArticle>>()));
            CreateMap<JObject, GoogleArticle>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => Guid.Parse(src["title"].Value<string>())))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src["link"].Value<string>()))
                .ForMember(dest => dest.Snippet, opt => opt.MapFrom(src => src["snippet"].Value<string>()));
        }
    }
}