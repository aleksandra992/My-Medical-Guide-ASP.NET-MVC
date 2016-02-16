using MyMedicalGuide.Data.Models;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IPatientService
    {
        string Add(Patient patient);
    }
}
