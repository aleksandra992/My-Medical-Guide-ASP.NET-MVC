using MyMedicalGuide.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMedicalGuide.Data.Models
{
    public class Doctor : BaseModel<string>
    {
        private ICollection<Patient> patients;

        private ICollection<Appointment> appointments;

        private ICollection<CustomAppointment> customAppointments;

        private ICollection<PatientRequest> patientRequests;

        private ICollection<Document> documents;

        public Doctor()
        {
            this.patients = new HashSet<Patient>();
            this.appointments = new HashSet<Appointment>();
            this.customAppointments = new HashSet<CustomAppointment>();
            this.patientRequests = new HashSet<PatientRequest>();
            this.documents = new HashSet<Document>();

        }

        [Required]
        [ForeignKey("User")]
        public override string Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }

        public virtual User User { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public int? HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

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
        public virtual ICollection<Appointment> Appointments
        {
            get
            {
                return this.appointments;
            }
            set
            {
                this.appointments = value;
            }
        }

        public virtual ICollection<CustomAppointment> CustomAppointments
        {
            get
            {
                return this.customAppointments;
            }
            set
            {
                this.customAppointments = value;
            }
        }

        public virtual ICollection<PatientRequest> PatientRequests
        {
            get
            {
                return this.patientRequests;
            }
            set
            {
                this.patientRequests = value;
            }
        }

        public virtual ICollection<Document> Documents
        {
            get
            {
                return this.documents;
            }
            set
            {
                this.documents = value;
            }
        }
    }
}
