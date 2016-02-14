using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;

namespace MyMedicalGuide.Web.Models.Departments
{
    public class DepartmentViewModel : IMapFrom<Department>
    {
        public string Picture { get; set; }

        public string Name { get; set; }
    }
}
