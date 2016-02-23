using MyMedicalGuide.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IDepartmentsService
    {
        IQueryable<Department> GetAll();

        Department GetById(int id);

        Department GetDepartmentByIdFromParticularHospital(int departmentId, int hospitalId);
    }
}
