using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyMedicalGuide.Web.Models.Departments;

namespace MyMedicalGuide.Web.Models.Doctors
{
    public class DoctorGridViewModel : IMapFrom<Doctor>, IMapTo<Doctor>, IHaveCustomMappings
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public string Id { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<DepartmentNameViewModel> Departments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {

            configuration.CreateMap<Doctor, DoctorGridViewModel>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName))
                .ForMember(x => x.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));
        }
    }
}
