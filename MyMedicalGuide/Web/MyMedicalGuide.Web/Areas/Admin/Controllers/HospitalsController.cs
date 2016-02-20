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

namespace MyMedicalGuide.Web.Areas.Admin.Controllers
{
    public class HospitalsController : Controller
    {
        private MyMedicalGuideDbContext db = new MyMedicalGuideDbContext();

        public ActionResult Details(int id)
        {
            this.ViewBag.HospitalId = id;
            return View();
        }

        public ActionResult Doctors_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            IQueryable<MyMedicalGuide.Data.Models.Doctor> doctors = db.Doctors.Where(x => x.Hospital.Id == id);
            DataSourceResult result = doctors.ToDataSourceResult(request, doctor => new
            {
                Id = doctor.Id,
                CreatedOn = doctor.CreatedOn,
                ModifiedOn = doctor.ModifiedOn,
                IsDeleted = doctor.IsDeleted,
                DeletedOn = doctor.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Doctors_Create([DataSourceRequest]DataSourceRequest request, MyMedicalGuide.Data.Models.Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var entity = new MyMedicalGuide.Data.Models.Doctor
                {
                    CreatedOn = doctor.CreatedOn,
                    ModifiedOn = doctor.ModifiedOn,
                    IsDeleted = doctor.IsDeleted,
                    DeletedOn = doctor.DeletedOn
                };

                db.Doctors.Add(entity);
                db.SaveChanges();
                doctor.Id = entity.Id;
            }

            return Json(new[] { doctor }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Doctors_Update([DataSourceRequest]DataSourceRequest request, MyMedicalGuide.Data.Models.Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var entity = new MyMedicalGuide.Data.Models.Doctor
                {
                    Id = doctor.Id,
                    CreatedOn = doctor.CreatedOn,
                    ModifiedOn = doctor.ModifiedOn,
                    IsDeleted = doctor.IsDeleted,
                    DeletedOn = doctor.DeletedOn
                };

                db.Doctors.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { doctor }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Doctors_Destroy([DataSourceRequest]DataSourceRequest request, MyMedicalGuide.Data.Models.Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var entity = new MyMedicalGuide.Data.Models.Doctor
                {
                    Id = doctor.Id,
                    CreatedOn = doctor.CreatedOn,
                    ModifiedOn = doctor.ModifiedOn,
                    IsDeleted = doctor.IsDeleted,
                    DeletedOn = doctor.DeletedOn
                };

                db.Doctors.Attach(entity);
                db.Doctors.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { doctor }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
