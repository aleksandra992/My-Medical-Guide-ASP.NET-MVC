namespace MyMedicalGuide.Web.Models.Departments
{
    using Data.Models;
    using Infrastructure.Mapping;
    using MyMedicalGuide.Web.Models.Doctors;
    using System.Collections.Generic;

    public class DepartmentDetailsViewModel : IMapFrom<Department>
    {


        public string Description { get; set; }

        public IEnumerable<DoctorBasicViewModel> Doctors { get; set; }
    }
}
