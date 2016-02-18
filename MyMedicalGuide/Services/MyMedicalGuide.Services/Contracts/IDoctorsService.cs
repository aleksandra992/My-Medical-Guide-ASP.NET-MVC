namespace MyMedicalGuide.Services.Contracts
{

    using System.Linq;

    using MyMedicalGuide.Data.Models;

    public interface IDoctorsService
    {
        IQueryable<Doctor> GetAll();

    }
}
