using MyMedicalGuide.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMedicalGuide.Data.Models
{
    public class Report : BaseModel<int>
    {
        [ForeignKey("Appointment")]
        public override int Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public string HistoryOfIlness { get; set; }

        public string Medications { get; set; }

        public string Summary { get; set; }

        public virtual Appointment Appointment { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
