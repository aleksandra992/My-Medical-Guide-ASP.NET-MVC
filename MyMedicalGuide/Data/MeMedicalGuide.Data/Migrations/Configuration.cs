namespace MyMedicalGuide.Data.Migrations
{
    using System;
    using System.Collections;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity.Core;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MyMedicalGuideDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyMedicalGuideDbContext context)
        {
            this.SeedRoles(context);
            this.SeedAdmin(context);
            var patients = this.SeedPatients(context);
            var departments = this.SeedDepartments(context);
            var doctors = this.SeedDoctors((IList<Department>)departments, context);
            var hospitals = this.SeedHospitals(patients, doctors, departments, context); ;
        }

        private void SeedRoles(MyMedicalGuideDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = "Admin" };
                roleManager.Create(adminRole);

                var hospitalAdmin = new IdentityRole { Name = "HospitalAdmin" };

                roleManager.Create(hospitalAdmin);

                var doctorRole = new IdentityRole { Name = "Doctor" };
                roleManager.Create(doctorRole);

                var userRole = new IdentityRole { Name = "User" };
                roleManager.Create(userRole);


                var patientRole = new IdentityRole { Name = "Patient" };
                roleManager.Create(patientRole);

                context.SaveChanges();
            }
        }

        private void SeedAdmin(MyMedicalGuideDbContext context)
        {
            var passHasher = new PasswordHasher();
            if (!context.Users.Any())
            {

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var adminAleksandra = new User()
                {
                    Email = "admin@admin.com",
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin",
                    PasswordHash = passHasher.HashPassword("admin")
                };

                userManager.Create(adminAleksandra);
                userManager.AddToRole(adminAleksandra.Id, "Admin");
                context.SaveChanges();
            }
        }

        private ICollection<Patient> SeedPatients(MyMedicalGuideDbContext context)
        {

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var passhasher = new PasswordHasher();
            var patients = new List<Patient>();
            if (!context.Patients.Any())
            {
                var userGoran = new User()
                {
                    FirstName = "Goran",
                    LastName = "Cvetkov",
                    PasswordHash = passhasher.HashPassword("Goran"),
                    PhoneNumber = "0035986123456",
                    Email = "goran@yahoo.com",
                    UserName = "goran"
                };
                userManager.Create(userGoran);
                userManager.AddToRole(userGoran.Id, "Patient");

                var pacient = new Patient() { User = userGoran, SSN = "1111111111", CreatedOn = DateTime.Now };

                context.Patients.AddOrUpdate(pacient);
                patients.Add(pacient);
                context.SaveChanges();

            }
            return patients;
        }

        private ICollection<Department> SeedDepartments(MyMedicalGuideDbContext context)
        {
            var departments = new List<Department>();
            if (!context.Departments.Any())
            {
                var departmentsPart1 = new List<Department>()
                {
                   new Department
                   {
                       Name = "CardioSurgery",
                       Picture = "/Content/Departments/1.jpg",
                       Description = "Cardiothoracic surgery is the"
                                     + " field of medicine involved in "
                                     + "surgical treatment of organs inside "
                                     + "the thorax (the chest)—generally treatment "
                                     + "of conditions of the heart (heart disease) and lungs (lung disease).",
                       CreatedOn=DateTime.Now
                   },

                    new Department
                    {
                        Name = "Urology",
                        Picture = "/Content/Departments/2.jpg",
                        Description = "Urology, also known as genitourinary surgery,"
                                      + " is the branch of medicine that focuses on"
                                      + " surgical and medical diseases of the male "
                                      + "and female urinary tract system and the male reproductive organs.",
                        CreatedOn =DateTime.Now
                    },

                    new Department
                    {
                        Name = "Cardiology",
                        Picture = "/Content/Departments/3.jpg",
                        Description = "Cardiologists are doctors"
                                      + " who specialize in diagnosing and treating"
                                      + " diseases or conditions of the heart and blood "
                                      + "vessels—the cardiovascular system. You might also"
                                      + " visit a cardiologist so you can learn about your risk"
                                      + " factors for heart disease and find out what measures you"
                                      + " can take for better heart health.",
                        CreatedOn=DateTime.Now
                    }
                };

                var departmentsPart2 = new List<Department>()
                {
                      new Department() { Name = "Neurology",CreatedOn = DateTime.Now,Picture="/Content/Departments/4.jpg",Description="A neurologist is a doctor who specializes in treating diseases of the nervous system. The nervous system comprises the central and peripheral nervous system. This complex system involves the spinal cord and the brain."},
                    new Department() { Name = "Nuclear Medicine",CreatedOn = DateTime.Now,Picture="/Content/Departments/5.jpg",Description="Nuclear medicine is a branch of medical imaging that uses small amounts of radioactive material to diagnose and determine the severity of or treat a variety of diseases, including many types of cancers, heart disease, gastrointestinal, endocrine, neurological disorders and other abnormalities within the body." },
                    new Department() { Name = "Pediatrics",CreatedOn = DateTime.Now,Picture="/Content/Departments/6.jpg",Description="Pediatrics (also spelled paediatrics or p?diatrics) is the branch of medicine that deals with the medical care of infants, children, and adolescents, and the age limit usually ranges from birth up to 18 years of age (in some places until completion of secondary education, and until age 21 in the United States).[citation needed] A medical practitioner who specializes in this area is known as a pediatrician, or paediatrician." }
                };

                context.Departments.AddOrUpdate(departmentsPart1.ToArray());
                context.Departments.AddOrUpdate(departmentsPart2.ToArray());
                context.SaveChanges();
                departments.AddRange(departmentsPart1);
                departments.AddRange(departmentsPart2);
            }

            return departments;
        }

        private ICollection<Doctor> SeedDoctors(IList<Department> departments, MyMedicalGuideDbContext context)
        {

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var passhasher = new PasswordHasher();
            var doctors = new List<Doctor>();
            if (!context.Doctors.Any())
            {
                var userDoctor = new User()
                {
                    Email = "rusev@yahoo.com",
                    FirstName = "Petar",
                    LastName = "Rusev",
                    PhoneNumber = "00359897456123",
                    UserName = "PRusev"
                };

                userManager.Create(userDoctor, "PRusev");

                userManager.AddToRole(userDoctor.Id, "Doctor");
                var doctor = new Doctor() { User = userDoctor, Department = departments[0], CreatedOn = DateTime.Now };
                context.Doctors.Add(doctor);
                context.SaveChanges();
                doctors.Add(doctor);
            }
            return doctors;

        }

        private ICollection<Hospital> SeedHospitals(
            ICollection<Patient> patients,
            ICollection<Doctor> doctors,
            ICollection<Department> departments,
            MyMedicalGuideDbContext context)
        {


            var hospitals = new List<Hospital>()
                                    {
                                        new Hospital()
                                            {
                                                Name = "Tokuda",
                                                Address = "Cherni vryh",
                                                Patients = patients,
                                                Doctors = doctors,
                                                Departments = departments,
                                                CreatedOn = DateTime.Now,
                                                Image="/Content/Hospitals/1.jpg"
                                            },
                                        new Hospital()
                                            {
                                                Name = "Some Hospital",
                                                Address = "Bogatisa",
                                                CreatedOn = DateTime.Now,
                                                Image="/Content/Hospitals/2.jpg"
                                            },
                                         new Hospital()
                                            {
                                                Name = "Sveti Lazar",
                                                Address = "Bogatisa",
                                                CreatedOn = DateTime.Now,
                                                Image="/Content/Hospitals/2.jpg"
                                            },
                                          new Hospital()
                                            {
                                                Name = "Another Hospital",
                                                Address = "Bogatisa",
                                                CreatedOn = DateTime.Now,
                                                Image="/Content/Hospitals/2.jpg"
                                            }
                                    };
            if (!context.Hospitals.Any())
            {
                context.Hospitals.AddOrUpdate(hospitals.ToArray());
                context.SaveChanges();
            }
            return hospitals;
        }





    }
}
