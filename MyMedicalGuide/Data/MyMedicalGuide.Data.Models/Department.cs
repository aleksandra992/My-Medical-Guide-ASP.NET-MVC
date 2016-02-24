using MyMedicalGuide.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Data.Models
{
    public class Department : BaseModel<int>
    {
        private ICollection<Doctor> doctors;
        private ICollection<Hospital> hospitals;

        public Department()
        {
            this.doctors = new HashSet<Doctor>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Doctor> Doctors
        {
            get
            {
                return this.doctors;
            }
            set
            {
                this.doctors = value;
            }
        }

        public virtual ICollection<Hospital> Hospitals
        {
            get
            {
                return this.hospitals;
            }
            set
            {
                this.hospitals = value;
            }
        }
    }
}
