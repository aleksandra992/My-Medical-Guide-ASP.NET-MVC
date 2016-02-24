using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace MyMedicalGuide.Web.Models.Hospitals
{
    public class HospitalGridViewModel : IMapTo<Hospital>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int NumOfPacients { get; set; }

        public int NumOfDoctors { get; set; }

        public int NumOfDepartments { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string Image { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Hospital, HospitalGridViewModel>()
                .ForMember(x => x.NumOfPacients, opt => opt.MapFrom(x => x.Patients.Count()))
                .ForMember(x => x.NumOfDoctors, opt => opt.MapFrom(x => x.Doctors.Count()))
             .ForMember(x => x.NumOfDepartments, opt => opt.MapFrom(x => x.Departments.Count()));
        }
    }
}
