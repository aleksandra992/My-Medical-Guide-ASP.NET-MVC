namespace MyMedicalGuide.Services
{
    using MyMedicalGuide.Services.Contracts;
    using MyMedicalGuide.Data.Models;
    using MyMedicalGuide.Data.Repositories;
    using System.Linq;
    using System;

    public class DepartmentsService : IDepartmentsService
    {
        private readonly IRepository<Department, int> departments;
        private readonly IRepository<Hospital, int> hospitals;

        public DepartmentsService(IRepository<Department, int> departments, IRepository<Hospital, int> hospitals)
        {
            this.departments = departments;
            this.hospitals = hospitals;
        }

        public IQueryable<Department> GetAll()
        {
            return this.departments.All();
        }

        public Department GetById(int id)
        {
            return this.departments.GetById(id);
        }

        public Department GetDepartmentByIdFromParticularHospital(int departmentId, int hospitalId)
        {

            return this.departments.All()
                .Where(x => x.Id == departmentId && x.Hospitals.Any(y => y.Id == hospitalId))
                .FirstOrDefault();

            //var hospital = this.hospitals.GetById(hospitalId);

            //return hospital
            //    .Departments
            //    .AsQueryable()
            //    .Where(x => x.Id == departmentId)
            //    .FirstOrDefault();
        }
    }
}
