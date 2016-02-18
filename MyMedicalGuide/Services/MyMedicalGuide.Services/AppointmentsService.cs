using MyMedicalGuide.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Data.Repositories;

namespace MyMedicalGuide.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IRepository<Appointment, int> appointmentRepo;
        public AppointmentsService(IRepository<Appointment, int> appointmentRepo)
        {
            this.appointmentRepo = appointmentRepo;
        }

        public void Add(Appointment appointment)
        {
            appointmentRepo.Add(appointment);
            appointmentRepo.SaveChanges();
        }
    }
}
