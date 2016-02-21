using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MyMedicalGuide.Data.Models;
using MyMedicalGuide.Data;
using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Models.Doctors;
using MyMedicalGuide.Web.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyMedicalGuide.Web.Areas.Admin.Controllers
{
    public class HospitalsController : BaseController
    {
        private readonly IHospitalsService hospitals;
        private readonly IDoctorsService doctors;
        private readonly IUsersService users;

        public HospitalsController(IHospitalsService hospitals, IDoctorsService doctors, IUsersService users)
        {
            this.hospitals = hospitals;
            this.doctors = doctors;
            this.users = users;
        }

        public ActionResult Details(int? id)
        {
            this.ViewBag.HospitalId = id;

            return this.View();
        }

        public ActionResult Doctors_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            ICollection<MyMedicalGuide.Data.Models.Doctor> doctors = this.hospitals.GetById(id).Doctors;
            DataSourceResult result = doctors.AsQueryable().To<DoctorGridViewModel>()
                .ToDataSourceResult(request);
            this.TempData["hospitalId"] = id;
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Doctors_Create([DataSourceRequest]DataSourceRequest request, DoctorGridViewModel doctor)
        {
            if (this.ModelState.IsValid)
            {
                var context = new MyMedicalGuideDbContext();
                var userManager = new UserManager<User>(new UserStore<User>(context));
                var userDoctor = new User()
                {
                    Email = doctor.Email,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    PhoneNumber = doctor.PhoneNumber,
                    UserName = doctor.Username
                };
                var hospitalId = this.TempData["hospitalId"];
                userManager.Create(userDoctor, doctor.Password);
                var DoctorDb = new MyMedicalGuide.Data.Models.Doctor() { User = userDoctor, HospitalId = (int)hospitalId, DepartmentId = 5, CreatedOn = DateTime.Now };
                context.Doctors.Add(DoctorDb);

                userManager.AddToRole(userDoctor.Id, "Doctor");

            }

            return this.Json(new[] { doctor }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Doctors_Update([DataSourceRequest]DataSourceRequest request, DoctorGridViewModel doctor)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<MyMedicalGuide.Data.Models.Doctor>(doctor);
                this.doctors.Update(entity);
            }

            return this.Json(new[] { doctor }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Doctors_Destroy([DataSourceRequest]DataSourceRequest request, DoctorGridViewModel doctor)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<MyMedicalGuide.Data.Models.Doctor>(doctor);
                this.doctors.Delete(entity);
            }

            return this.Json(new[] { doctor }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.doctors.Dispose();
            base.Dispose(disposing);
        }
    }
}
