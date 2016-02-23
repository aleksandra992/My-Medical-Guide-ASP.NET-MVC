namespace MyMedicalGuide.Services.Contracts
{
    using MyMedicalGuide.Data.Models;
    using System.Linq;

    public interface IHospitalsService
    {
        IQueryable<Hospital> GetAll();

        Hospital GetById(int id);

        void Add(Hospital hospital);

        void Update(Hospital hospital);

        void Delete(Hospital hospital);

        void Dispose();
    }
}
