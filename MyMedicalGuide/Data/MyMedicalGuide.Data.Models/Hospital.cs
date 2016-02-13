namespace MyMedicalGuide.Data.Models
{
    using System.Collections.Generic;

    public class Hospital
    {
        private ICollection<Doctor> doctors;

        private ICollection<Patient> patients;

        public Hospital()
        {
            this.doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

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

        public virtual ICollection<Patient> Patients
        {
            get
            {
                return this.patients;
            }
            set
            {
                this.patients = value;
            }
        }
    }
}
