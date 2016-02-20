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
    public class AdminHomeController : Controller
    {
        private MyMedicalGuideDbContext db = new MyMedicalGuideDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hospitals_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Hospital> hospitals = db.Hospitals;
            DataSourceResult result = hospitals.ToDataSourceResult(request, hospital => new {
                Id = hospital.Id,
                Image = hospital.Image,
                Name = hospital.Name,
                Address = hospital.Address,
                CreatedOn = hospital.CreatedOn,
                ModifiedOn = hospital.ModifiedOn,
                IsDeleted = hospital.IsDeleted,
                DeletedOn = hospital.DeletedOn
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Hospitals_Create([DataSourceRequest]DataSourceRequest request, Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                var entity = new Hospital
                {
                    Image = hospital.Image,
                    Name = hospital.Name,
                    Address = hospital.Address,
                    CreatedOn = hospital.CreatedOn,
                    ModifiedOn = hospital.ModifiedOn,
                    IsDeleted = hospital.IsDeleted,
                    DeletedOn = hospital.DeletedOn
                };

                db.Hospitals.Add(entity);
                db.SaveChanges();
                hospital.Id = entity.Id;
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Hospitals_Update([DataSourceRequest]DataSourceRequest request, Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                var entity = new Hospital
                {
                    Id = hospital.Id,
                    Image = hospital.Image,
                    Name = hospital.Name,
                    Address = hospital.Address,
                    CreatedOn = hospital.CreatedOn,
                    ModifiedOn = hospital.ModifiedOn,
                    IsDeleted = hospital.IsDeleted,
                    DeletedOn = hospital.DeletedOn
                };

                db.Hospitals.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Hospitals_Destroy([DataSourceRequest]DataSourceRequest request, Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                var entity = new Hospital
                {
                    Id = hospital.Id,
                    Image = hospital.Image,
                    Name = hospital.Name,
                    Address = hospital.Address,
                    CreatedOn = hospital.CreatedOn,
                    ModifiedOn = hospital.ModifiedOn,
                    IsDeleted = hospital.IsDeleted,
                    DeletedOn = hospital.DeletedOn
                };

                db.Hospitals.Attach(entity);
                db.Hospitals.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
