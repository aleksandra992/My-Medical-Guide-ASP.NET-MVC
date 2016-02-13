using System.Collections.Generic;

namespace MyMedicalGuide.Data.Models
{
    public class Patient
    {
        private ICollection<Report> reports;

        private ICollection<Doctor> doctors;

        private ICollection<Hospital> hospitals;

        public Patient()
        {
            this.reports = new HashSet<Report>();
            this.doctors = new HashSet<Doctor>();
            this.hospitals = new HashSet<Hospital>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Avatar { get; set; }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }
            set
            {
                this.reports = value;
            }
        }

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
