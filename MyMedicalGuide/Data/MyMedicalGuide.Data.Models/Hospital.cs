namespace MyMedicalGuide.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Hospital : BaseModel<int>
    {
        private ICollection<Doctor> doctors;

        private ICollection<Patient> patients;

        private ICollection<Department> departments;

        [Required]
        public string Image { get; set; }

        public Hospital()
        {
            this.doctors = new HashSet<Doctor>();
            this.patients = new HashSet<Patient>();
            this.departments = new HashSet<Department>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
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

        public virtual ICollection<Department> Departments
        {
            get
            {
                return this.departments;
            }
            set
            {
                this.departments = value;
            }
        }
    }
}
