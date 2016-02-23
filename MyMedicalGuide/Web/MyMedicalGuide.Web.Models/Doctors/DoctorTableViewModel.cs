using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MyMedicalGuide.Web.Models.Doctors
{
    public class DoctorTableViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int NumOfPatients { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Doctor, DoctorTableViewModel>()
              .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
              .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName))
              .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
              .ForMember(x => x.NumOfPatients, opt => opt.MapFrom(x => x.Patients.Count()));
        }
    }
}
