using System;
using AutoMapper;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;

namespace MyMedicalGuide.Web.Models.Requests
{
    public class RequestViewModel : IMapTo<PatientRequest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Message { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<PatientRequest, RequestViewModel>()
              .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
              .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName));
        }
    }
}
