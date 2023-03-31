using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.DTOs;
using AutoMapper;
using Google.Apis.YouTube.v3.Data;

namespace API.Profiles
{
    public class YouTubeMappingProfile : Profile
    {
        public YouTubeMappingProfile()
        {
            CreateMap<SearchListResponse, YouTubeDto>()
                .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.TotalResults, opt => opt.MapFrom(src => src.PageInfo.TotalResults))
                .ForMember(dest => dest.ResultsPerPage, opt => opt.MapFrom(src => src.PageInfo.ResultsPerPage));
        }
    }
}