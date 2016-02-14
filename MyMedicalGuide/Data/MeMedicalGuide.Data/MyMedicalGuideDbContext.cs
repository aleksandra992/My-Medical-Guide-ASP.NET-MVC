namespace MyMedicalGuide.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyMedicalGuide.Data.Models;
    using System.Data.Entity;
    public class MyMedicalGuideDbContext : IdentityDbContext<User>, IMyMedicalGuideDbContext
    {
        public MyMedicalGuideDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Hospital> Hospitals { get; set; }

        public virtual IDbSet<Doctor> Doctors { get; set; }

        public virtual IDbSet<Patient> Patients { get; set; }


        public virtual IDbSet<Appointment> Appointments { get; set; }

        public virtual IDbSet<CustomAppointment> CustomAppointments { get; set; }

        public virtual IDbSet<Report> Reports { get; set; }

        public virtual IDbSet<Department> Departments { get; set; }

        public static MyMedicalGuideDbContext Create()
        {
            return new MyMedicalGuideDbContext();
        }
    }
}
