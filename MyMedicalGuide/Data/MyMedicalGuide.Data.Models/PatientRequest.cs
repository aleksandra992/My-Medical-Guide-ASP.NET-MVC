using MyMedicalGuide.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Data.Models
{
    public class PatientRequest : BaseModel<int>
    {
        [Required]
        public string DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public string Message { get; set; }

        public bool IsApproved { get; set; }
    }
}
