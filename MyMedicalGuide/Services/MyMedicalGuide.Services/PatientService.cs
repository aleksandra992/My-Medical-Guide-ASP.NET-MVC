using System;
using System.Linq;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Data.Repositories;
using MyMedicalGuide.Services.Contracts;

namespace MyMedicalGuide.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient, string> patients;

        public PatientService(IRepository<Patient, string> patients)
        {
            this.patients = patients;
        }

        public string Add(Patient patient)
        {
            patients.Add(patient);
            patients.SaveChanges();
            return patient.Id;
        }

        public IQueryable<Patient> All()
        {
            return this.patients.All();
        }

        public IQueryable<Patient> GetAllByDoctorId(string doctorId)
        {
            return this.patients.All().Where(x => x.Doctors.Any(y => y.Id == doctorId));
        }

        public Patient GetById(string id)
        {
            return this.patients.GetById(id);
        }
    }
}
