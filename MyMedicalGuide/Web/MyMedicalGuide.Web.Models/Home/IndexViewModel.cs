using MyMedicalGuide.Web.Models.Hospitals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Web.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<BasicHospitalViewModel> Hospitals { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public string CurrentUrl { get; set; }
    }
}

