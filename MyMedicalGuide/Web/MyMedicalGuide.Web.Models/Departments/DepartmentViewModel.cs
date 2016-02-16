namespace MyMedicalGuide.Web.Models.Departments
{
    using AutoMapper;
    using MyMedicalGuide.Data.Models;
    using MyMedicalGuide.Web.Infrastructure.Mapping;

    public class DepartmentViewModel : IMapFrom<Department>, IHaveCustomMappings
    {
        public string Url { get; set; }

        public int Id { get; set; }

        public string Picture { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Department, DepartmentViewModel>()
                .ForMember(x => x.Url, opt => opt.MapFrom(x => "/Departments/Details/" + x.Id));
        }
    }
}
