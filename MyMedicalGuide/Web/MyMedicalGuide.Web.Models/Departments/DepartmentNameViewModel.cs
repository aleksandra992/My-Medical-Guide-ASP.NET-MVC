using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;

namespace MyMedicalGuide.Web.Models.Departments
{
    public class DepartmentNameViewModel : IMapFrom<Department>
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
