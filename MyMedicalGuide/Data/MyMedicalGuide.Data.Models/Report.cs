using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMedicalGuide.Data.Models
{
    public class Report
    {
        [Key, ForeignKey("Appointment")]
        public int AppointmentId { get; set; }

        public string HistoryOfIlness { get; set; }

        public string Medications { get; set; }

        public string Summary { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Appointment Appointment { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
