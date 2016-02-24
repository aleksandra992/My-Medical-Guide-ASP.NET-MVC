using MyMedicalGuide.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMedicalGuide.Data.Models
{
    public class Patient : BaseModel<string>
    {
        private ICollection<Report> reports;

        private ICollection<Doctor> doctors;

        private ICollection<Hospital> hospitals;

        private ICollection<Document> documents;

        public Patient()
        {
            this.reports = new HashSet<Report>();
            this.doctors = new HashSet<Doctor>();
            this.hospitals = new HashSet<Hospital>();
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

        public User User { get; set; }

        public string Avatar { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string SSN { get; set; }

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
