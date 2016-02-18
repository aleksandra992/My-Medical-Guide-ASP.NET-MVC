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

        public IQueryable<Doctor> GetAll()
        {
            return this.doctorsrepo.All();
        }
    }
}
