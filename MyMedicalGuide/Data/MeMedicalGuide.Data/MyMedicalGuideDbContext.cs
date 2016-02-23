namespace MyMedicalGuide.Data
{
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MyMedicalGuide.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
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

        public virtual IDbSet<PatientRequest> PatientRequests { get; set; }

        public static MyMedicalGuideDbContext Create()
        {
            return new MyMedicalGuideDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
