namespace MyMedicalGuide.Web.Controllers
{
    using Models.Departments;
    using MyMedicalGuide.Services.Contracts;
    using MyMedicalGuide.Web.Models.Hospitals;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HospitalsController : BaseController
    {
        private readonly IHospitalsService hospitalsService;

        public HospitalsController(IHospitalsService service)
        {
            this.hospitalsService = service;
        }

        [HttpGet]
        public ActionResult All()
        {
            var hospitals = hospitalsService.GetAll();
            var viewModelHospitals = this.Mapper.Map<IEnumerable<BasicHospitalViewModel>>(hospitals);
            return View(viewModelHospitals);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var departments = hospitalsService.GetById(id).Departments;
            var departmentsResult = this.Mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View(departmentsResult);
        }
    }
}