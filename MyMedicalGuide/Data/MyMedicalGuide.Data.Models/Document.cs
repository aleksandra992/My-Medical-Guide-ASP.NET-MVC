using MyMedicalGuide.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Data.Models
{
    public class Document : BaseModel<int>
    {
        public Document()
        {
            this.FileName = Guid.NewGuid();
        }

        [Required]
        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [Required]
        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        public Guid FileName { get; set; }

        [Required]
        public string RealFileName { get; set; }

        [Required]
        public string Extension { get; set; }

    }
}
