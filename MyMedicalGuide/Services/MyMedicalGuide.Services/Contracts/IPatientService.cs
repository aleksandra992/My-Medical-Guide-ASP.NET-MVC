using MyMedicalGuide.Data.Models;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IPatientService
    {
        int Add(Patient patient);
    }
}
