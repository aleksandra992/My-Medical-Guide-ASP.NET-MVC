using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MyMedicalGuide.Web.Models.Patients
{
    public class PatientViewModel : IMapFrom<Patient>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SSN { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Patient, PatientViewModel>()
              .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
              .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName));
        }
    }
}
