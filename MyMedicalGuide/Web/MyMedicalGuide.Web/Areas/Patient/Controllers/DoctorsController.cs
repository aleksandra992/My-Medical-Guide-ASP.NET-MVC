using MyMedicalGuide.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Patient.Controllers
{
    public class DoctorsController : BaseController
    {
        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }
    }
}