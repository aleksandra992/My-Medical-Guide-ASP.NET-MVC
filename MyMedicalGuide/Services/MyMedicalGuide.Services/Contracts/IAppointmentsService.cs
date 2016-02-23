using MyMedicalGuide.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Services.Contracts
{
    public interface IAppointmentsService
    {
        void Add(Appointment appointment);
    }
}
