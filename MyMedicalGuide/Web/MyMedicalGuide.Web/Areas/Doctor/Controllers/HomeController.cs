using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Doctor.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPatientService patients;

        public HomeController(IPatientService patients)
        {
            this.patients = patients;
        }

        
    }
}