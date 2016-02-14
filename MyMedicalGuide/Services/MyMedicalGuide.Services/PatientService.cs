using System;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Data.Repositories;
using MyMedicalGuide.Services.Contracts;

namespace MyMedicalGuide.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> patients;

        public PatientService(IRepository<Patient> patients)
        {
            this.patients = patients;
        }

        public int Add(Patient patient)
        {
            patients.Add(patient);
            patients.SaveChanges();
            return patient.Id;
        }
    }
}
