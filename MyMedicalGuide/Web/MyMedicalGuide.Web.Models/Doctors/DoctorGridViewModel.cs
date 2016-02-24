using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyMedicalGuide.Web.Models.Departments;
using System.ComponentModel.DataAnnotations;

namespace MyMedicalGuide.Web.Models.Doctors
{
    public class DoctorGridViewModel : IMapFrom<Doctor>, IMapTo<Doctor>, IHaveCustomMappings
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
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
