namespace MyMedicalGuide.Services.Contracts
{

    using System.Linq;

    using MyMedicalGuide.Data.Models;

    public interface IDoctorsService
    {
        IQueryable<Doctor> GetAll();

        void Add(Doctor doctor);

        void Update(Doctor doctor);

        void Delete(Doctor doctor);

        void Dispose();

        IQueryable<Doctor> GetAllDoctorsFromDepartmentHospital(int hospitalId, int departmentId);

        IQueryable<Doctor> GetDoctors(string filter);

        Doctor GetById(string id);

        void AddPatient(string doctorId, Patient patient);

    }
}
