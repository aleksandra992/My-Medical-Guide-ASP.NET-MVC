using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMedicalGuide.Data.Repositories;

namespace MyMedicalGuide.Services
{
    using Data.Models;
    using MyMedicalGuide.Services.Contracts;

    public class DoctorsService : IDoctorsService
    {
        private readonly IRepository<Doctor, string> doctorsrepo;

        public DoctorsService(IRepository<Doctor, string> doctorsrepo)
        {
            this.doctorsrepo = doctorsrepo;
        }

        public void Add(Doctor doctor)
        {
            this.doctorsrepo.Add(doctor);
            this.doctorsrepo.SaveChanges();
        }

        public void Delete(Doctor doctor)
        {
            this.doctorsrepo.Delete(doctor);
            this.doctorsrepo.SaveChanges();
        }

        public IQueryable<Doctor> GetAll()
        {
            return this.doctorsrepo.All();
        }

        public void Update(Doctor doctor)
        {
            this.doctorsrepo.Update(doctor);
            this.doctorsrepo.SaveChanges();
        }

        public void Dispose()
        {
            this.doctorsrepo.Dispose();
        }

        public IQueryable<Doctor> GetAllDoctorsFromDepartmentHospital(int hospitalId, int departmentId)
        {
            return this.doctorsrepo
                 .All()
                 .Where(x => x.HospitalId == hospitalId && x.DepartmentId == departmentId);
        }
    }
}
