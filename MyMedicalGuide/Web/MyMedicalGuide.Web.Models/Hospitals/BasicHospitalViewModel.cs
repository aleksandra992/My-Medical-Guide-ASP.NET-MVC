namespace MyMedicalGuide.Web.Models.Hospitals
{
    using System;
    using AutoMapper;
    using MyMedicalGuide.Data.Models;
    using MyMedicalGuide.Web.Infrastructure.Mapping;

    public class BasicHospitalViewModel : IMapFrom<Hospital>, IHaveCustomMappings
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Hospital, BasicHospitalViewModel>()
              .ForMember(x => x.Url, opt => opt.MapFrom(x => "/Hospitals/Details/" + x.Id));
        }
    }
}
