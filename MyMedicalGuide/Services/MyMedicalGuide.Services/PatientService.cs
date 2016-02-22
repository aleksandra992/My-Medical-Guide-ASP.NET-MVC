using System;
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

        public Patient GetById(string id)
        {
            return this.patients.GetById(id);
        }
    }
}
