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
    public class YahooFinanceMappingProfile : Profile
    {
        public YahooFinanceMappingProfile()
        {
            CreateMap<JObject, YahooFinanceDto>()
                .ForMember(dest => dest.News, opt => opt.MapFrom(src => src["news"].ToObject<IList<YahooArticle>>()));
            CreateMap<JObject, YahooArticle>()
                .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => Guid.Parse(src["uuid"].Value<string>())))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src["title"].Value<string>()))
                .ForMember(dest => dest.Link, opt => opt.MapFrom(src => src["link"].Value<string>()))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src["publisher"].Value<string>()));
        }
    }
}