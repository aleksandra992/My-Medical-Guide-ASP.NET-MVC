using MyMedicalGuide.Data.Common.Models;
using System;
using System.Collections.Generic;
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

        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public string PatientId { get; set; }

        public Patient Patient { get; set; }

        public Guid FileName { get; set; }

        public string RealFileName { get; set; }

        public string Extension { get; set; }

    }
}
