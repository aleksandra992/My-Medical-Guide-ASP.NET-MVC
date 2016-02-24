using MyMedicalGuide.Data.Models;
using System.Linq;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IPatientService
    {
        string Add(Patient patient);

        Patient GetById(string id);

        IQueryable<Patient> GetAllByDoctorId(string doctorId);

        IQueryable<Patient> All();
    }
}
