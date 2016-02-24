using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Web.Models.Patients
{
    public class PagingPatientViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string CurrentUrl { get; set; }

        public IEnumerable<PatientViewModel> Patients { get; set; }
    }
}
