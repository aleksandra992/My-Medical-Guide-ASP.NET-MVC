namespace MyMedicalGuide.Web.Controllers
{
    using Data.Models;
    using Models.Departments;
    using MyMedicalGuide.Services.Contracts;
    using MyMedicalGuide.Web.Models.Hospitals;
    using Services.Web;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HospitalsController : BaseController
    {
        private readonly IHospitalsService hospitalsService;
        private readonly ICacheService cacheService;

        public HospitalsController(IHospitalsService service, ICacheService cacheService)
        {
            this.hospitalsService = service;
            this.cacheService = cacheService;
        }

        [HttpGet]
        public ActionResult All()
        {
            var hospitals = cacheService.Get<IEnumerable<Hospital>>("hospitals", () => { return hospitalsService.GetAll().ToList(); }, 60);
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