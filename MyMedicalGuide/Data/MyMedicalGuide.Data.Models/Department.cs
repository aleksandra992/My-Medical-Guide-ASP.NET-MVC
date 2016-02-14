using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Data.Models
{
    public class Department
    {
        private ICollection<Doctor> doctors;
        private ICollection<Hospital> hospitals;

        public Department()
        {
            this.doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

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
