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
using Microsoft.AspNet.Identity;
using MyMedicalGuide.Web.Models.Requests;
using MyMedicalGuide.Web.Infrastructure.Mapping;
using MyMedicalGuide.Web.Controllers;

namespace MyMedicalGuide.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class RequestsController : BaseController
    {
        private readonly IPatientRequestService requests;
        private readonly IPatientService patients;
        private readonly IUsersService users;
        private readonly IDoctorsService doctors;

        public RequestsController(
            IPatientRequestService requests,
            IPatientService patients,
            IUsersService users,
            IDoctorsService doctors)
        {
            this.requests = requests;
            this.patients = patients;
            this.users = users;
            this.doctors = doctors;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult PatientRequests_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<PatientRequest> patientRequests = this.requests
                .GetByDoctorId(this.User.Identity.GetUserId())
                .Where(x => x.IsApproved == false);
            DataSourceResult result = patientRequests.To<RequestViewModel>()
                .ToDataSourceResult(request);
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PatientRequests_Update([DataSourceRequest]DataSourceRequest request, RequestViewModel patientRequest)
        {

            if (this.ModelState.IsValid)
            {
                var entity = this.requests.GetById(patientRequest.Id);

                var patient = this.patients.GetById(entity.UserId);
                //if (patient == null)
                //{
                //    patient = new MyMedicalGuide.Data.Models.Patient
                //    {
                //        Id = entity.UserId
                //    };

                //}

                this.doctors.AddPatient(entity.DoctorId, patient);

                entity.IsApproved = patientRequest.IsApproved;
                this.requests.Update(entity);

            }

            return this.Json(new[] { patientRequest }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PatientRequests_Destroy([DataSourceRequest]DataSourceRequest request, RequestViewModel patientRequest)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<PatientRequest>(patientRequest);
                this.requests.Delete(entity);
            }

            return this.Json(new[] { patientRequest }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.requests.Dispose();
            base.Dispose(disposing);
        }
    }
}
