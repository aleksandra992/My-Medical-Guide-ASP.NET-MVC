using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Services
{
    using Data.Models;
    using MyMedicalGuide.Services.Contracts;

    public class DoctorsService : IDoctorsService
    {
        public IQueryable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
