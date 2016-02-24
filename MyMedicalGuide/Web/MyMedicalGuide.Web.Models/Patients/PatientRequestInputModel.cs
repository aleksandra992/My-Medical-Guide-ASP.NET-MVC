using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Web.Models.Patients
{
    public class PatientRequestInputModel : IMapTo<PatientRequest>
    {
        [Required]
        public string DoctorId { get; set; }

        public string Message { get; set; }
    }
}
