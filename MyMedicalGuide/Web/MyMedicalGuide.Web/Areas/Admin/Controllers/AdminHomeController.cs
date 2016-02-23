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
using MyMedicalGuide.Web.Models.Hospitals;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Controllers;

namespace MyMedicalGuide.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : BaseController
    {
        private readonly IHospitalsService hospitals;

        public AdminHomeController(IHospitalsService hospitals)
        {
            this.hospitals = hospitals;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hospitals_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Hospital> hospitals = this.hospitals.GetAll();
            DataSourceResult result = hospitals.To<HospitalGridViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Hospitals_Create([DataSourceRequest]DataSourceRequest request, HospitalGridViewModel hospital)
        {
            if (ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Hospital>(hospital);
                this.hospitals.Add(entity);
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Hospitals_Update([DataSourceRequest]DataSourceRequest request, HospitalGridViewModel hospital)
        {
            if (ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Hospital>(hospital);
                this.hospitals.Update(entity);
            }

            return Json(new[] { hospital }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Hospitals_Destroy([DataSourceRequest]DataSourceRequest request, HospitalGridViewModel hospital)
        {
            if (ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Hospital>(hospital);
                this.hospitals.Delete(entity);
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
            this.hospitals.Dispose();
            base.Dispose(disposing);
        }
    }
}
