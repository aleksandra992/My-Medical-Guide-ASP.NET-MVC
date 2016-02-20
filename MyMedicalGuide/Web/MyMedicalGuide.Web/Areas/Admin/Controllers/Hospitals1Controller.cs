using MyMedicalGuide.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Hospitals1Controller : BaseController
    {
        public ActionResult Details(int id)
        {
            return this.View();
        }
    }
}