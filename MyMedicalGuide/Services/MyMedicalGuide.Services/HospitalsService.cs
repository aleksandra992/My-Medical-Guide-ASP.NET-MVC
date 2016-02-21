namespace MyMedicalGuide.Services
{
    using MyMedicalGuide.Services.Contracts;
    using System.Linq;
    using MyMedicalGuide.Data.Models;
    using MyMedicalGuide.Data.Repositories;
    using System;

    public class HospitalsService : IHospitalsService
    {
        private readonly IRepository<Hospital, int> hospitals;

        public HospitalsService(IRepository<Hospital, int> hospitals)
        {
            this.hospitals = hospitals;
        }

        public void Add(Hospital hospital)
        {
            this.hospitals.Add(hospital);
            this.hospitals.SaveChanges();
        }

        public void Delete(Hospital hospital)
        {
            this.hospitals.Delete(hospital);
            this.hospitals.SaveChanges();
        }

        public IQueryable<Hospital> GetAll()
        {
            return this.hospitals.All();
        }

        public Hospital GetById(int id)
        {
            return this.hospitals.GetById(id);
        }

        public void Update(Hospital hospital)
        {
            this.hospitals.Update(hospital);
            this.hospitals.SaveChanges();
        }

        public void Dispose()
        {
            this.hospitals.Dispose();
        }

    }
}
