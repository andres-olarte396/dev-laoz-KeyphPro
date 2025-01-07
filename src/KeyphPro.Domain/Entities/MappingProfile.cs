using AutoMapper;
using KeyphPro.Domain.Entities.Database;
using KeyphPro.Domain.Entities.Models;

namespace StoreVO.Core.Entities.Commond
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AssessmentModel, Assessment>().ReverseMap();

            CreateMap<MetricModel, Metric>().ReverseMap();

            CreateMap<UserModel, User>().ReverseMap();
        }
    }
}
