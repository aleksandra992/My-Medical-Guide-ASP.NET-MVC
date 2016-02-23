namespace MyMedicalGuide.Web.Models.Doctors
{
    using AutoMapper;
    using Data.Models;
    using MyMedicalGuide.Web.Infrastructure.Mapping;

    public class DoctorBasicViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Doctor, DoctorBasicViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.FirstName + " " + x.User.LastName));
        }
    }
}
