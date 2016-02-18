using MyMedicalGuide.Data.Common.Models;
using System;

namespace MyMedicalGuide.Data.Models
{
    public class Appointment : BaseModel<int>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Report Report { get; set; }

    }
}
