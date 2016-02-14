namespace MyMedicalGuide.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedRoles(context);
            SeedAdmin(context);
            SeedDepartmentsHospitalsDoctors(context);
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

                context.SaveChanges();
            }
        }

        internal static void SeedDepartmentsHospitalsDoctors(MyMedicalGuideDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            if (!context.Departments.Any())
            {
                var departmentsPart1 = new List<Department>()
                {
                    new Department() {Name = "CardioSurgery",Picture="../Content/Departments/1.jpg"},
                    new Department() { Name = "Urology",Picture="../Content/Departments/2.jpg" },
                    new Department() { Name = "Cardiology",Picture="../Content/Departments/3.jpg" },

                };
                var departmentsPart2 = new List<Department>()
                {
                      new Department() { Name = "Neurology",Picture="../Content/Departments/4.jpg"},
                    new Department() { Name = "Nuclear Medicine",Picture="../Content/Departments/5.jpg" },
                    new Department() { Name = "Pediatrics",Picture="../Content/Departments/6.jpg" }
                };

                context.Departments.AddOrUpdate(departmentsPart1.ToArray());
                context.Departments.AddOrUpdate(departmentsPart2.ToArray());
                var hospitals = new List<Hospital>()
                {
                    new Hospital()
                    {
                        Name = "Tokuda",
                        Address = "Cherni vryh",
                        Departments = departmentsPart1,
                    },
                    new Hospital()
                    {
                        Name="Sveta Ana",
                        Address="Bogatisa",
                        Departments=departmentsPart2
                    }
                };

                context.Hospitals.AddOrUpdate(hospitals.ToArray());
                var passhasher = new PasswordHasher();
                var user = new User()
                {
                    Email = "rusev@yahoo.com",
                    FirstName = "Petar",
                    LastName = "Rusev",
                    PhoneNumber = "00359897456123",
                    UserName = "PRusev",
                    PasswordHash = passhasher.HashPassword("PRusev")
                };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Doctor");
                var doctor = new Doctor()
                {
                    UserId = user.Id,
                    DepartmentId = departmentsPart1[0].Id,
                    Hospital = hospitals[0]
                };
                context.Doctors.Add(doctor);
                context.Hospitals.AddOrUpdate(hospitals.ToArray());

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
                userManager.AddToRole(userGoran.Id, "User");
                var pacient = new Patient()
                {
                    UserId = userGoran.Id,
                    SSN = "1111111111",
                };
                pacient.Hospitals.Add(hospitals[0]);
                pacient.Doctors.Add(doctor);
                context.Patients.AddOrUpdate(pacient);
                context.SaveChanges();
            }
        }

        public void SeedAdmin(MyMedicalGuideDbContext context)
        {
            if (!context.Users.Any())
            {

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var adminAleksandra = new User()
                {
                    Email = "aleksandra@gmail.com",
                    UserName = "aleksandra",
                    FirstName = "Aleksandra",
                    LastName = "Stojceva",
                };

                userManager.Create(adminAleksandra, "123456");
                userManager.AddToRole(adminAleksandra.Id, "Admin");

                context.SaveChanges();
            }
        }
    }
}
