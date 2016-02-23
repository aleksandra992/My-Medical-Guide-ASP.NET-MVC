using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Web.Models.Appointments
{

    public class AppointmentInputModel : IMapTo<Appointment>
    {
        public IEnumerable<DoctorBasicViewModel> Doctors { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string DoctorId { get; set; }
    }
}
