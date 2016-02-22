using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Patient.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Patient/Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}