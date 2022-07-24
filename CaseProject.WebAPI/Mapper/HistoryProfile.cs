using AutoMapper;
using CaseProject.Entities.Concrete;
using CaseProject.Entities.Concrete.DTOs;
using CaseProject.WebAPI.Models;

namespace CaseProject.WebAPI.Mapper
{
    public class HistoryProfile:Profile
    {
        public HistoryProfile()
        {
            CreateMap<HistoryTRAddDto, History>().ReverseMap();
            CreateMap<HistoryITAddDto, History>().ReverseMap();
            CreateMap<HistoryModel, History>().ReverseMap();
            CreateMap<HistoryCategoryModel, HistoryCategory>().ReverseMap();
            CreateMap<LanguageModel, Language>().ReverseMap();
        }
    }
}
