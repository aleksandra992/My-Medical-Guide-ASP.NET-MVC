namespace MyMedicalGuide.Services
{
    using MyMedicalGuide.Services.Contracts;
    using MyMedicalGuide.Data.Models;
    using MyMedicalGuide.Data.Repositories;
    using System.Linq;

    public class DepartmentsService : IDepartmentsService
    {
        private readonly IRepository<Department> departments;

        public DepartmentsService(IRepository<Department> departments)
        {
            this.departments = departments;
        }

        public IQueryable<Department> GetAll()
        {
            return this.departments.All();
        }
    }
}
