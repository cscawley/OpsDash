using AutoMapper;
using TrivyDash.Dtos;
using TrivyDash.Models;

namespace TrivyDash.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportReadDto>();
            CreateMap<ReportCreateDto, Report>();
        }
    }
}