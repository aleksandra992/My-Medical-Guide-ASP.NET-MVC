using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MyMedicalGuide.Web.Models.Documents
{
    public class DocumentViewModel : IMapFrom<Document>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string File { get; set; }

        public string DoctorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Document, DocumentViewModel>()
             .ForMember(x => x.DoctorName, opt => opt.MapFrom(x => x.Doctor.User.FirstName + " " + x.Doctor.User.LastName))
             .ForMember(x => x.File, opt => opt.MapFrom(x => x.RealFileName));
        }
    }
}
