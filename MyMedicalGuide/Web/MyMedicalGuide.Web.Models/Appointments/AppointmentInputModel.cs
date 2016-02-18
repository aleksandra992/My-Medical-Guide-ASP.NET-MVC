using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Web.Models.Appointments
{

    public class AppointmentInputModel
    {
        public IEnumerable<string> Doctors { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DoctorId { get; set; }
    }
}
