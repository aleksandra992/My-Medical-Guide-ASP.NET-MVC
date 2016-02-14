using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Web.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDepartmentsService departmentsService;

        public HomeController(IDepartmentsService service)
        {
            this.departmentsService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Departments()
        {
            //    var departments = departmentsService.GetAll().Select(x => new DepartmentViewModel()
            //    {
            //        Name = x.Name,
            //        Picture = x.Picture
            //    }).ToList();
            var departments = departmentsService.GetAll();
            var viewModelDepartments = this.Mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View(viewModelDepartments);
        }
    }
}