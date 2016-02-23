namespace MyMedicalGuide.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Mapping;
    using Models.Departments;
    using Models.Home;
    using MyMedicalGuide.Services.Contracts;
    using MyMedicalGuide.Web.Models.Hospitals;
    using Services.Web;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HospitalsController : BaseController
    {
        private readonly IHospitalsService hospitalsService;
        private readonly ICacheService cacheService;

        private const int ItemsPerPage = 3;

        public HospitalsController(IHospitalsService service, ICacheService cacheService)
        {
            this.hospitalsService = service;
            this.cacheService = cacheService;
        }

        [HttpGet]
        public ActionResult All(int id = 1)
        {
            var search = this.Request.QueryString["search"];
            var page = id;
            var allItemsCount = this.hospitalsService
                .GetAll()
                .Count();

            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var skip = (page - 1) * ItemsPerPage;
            List<BasicHospitalViewModel> resultHospitals;
            if (search != null)
            {

                resultHospitals = this.hospitalsService
                   .GetAll()
                   .Where(x => x.Name.Contains(search))
                   .To<BasicHospitalViewModel>()
                   .ToList();
            }
            else
            {
                resultHospitals = this.hospitalsService
                   .GetAll()
                   .OrderBy(x => x.Id)
                   .Skip(skip)
                   .Take(ItemsPerPage)
                   .To<BasicHospitalViewModel>()
                   .ToList();
            }
            var resultModel = new IndexViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Hospitals = resultHospitals
            };

            //var hospitals = this.cacheService
            //    .Get<IEnumerable<Hospital>>("hospitals", () => { return this.hospitalsService.GetAll().ToList(); }, 60);
            var viewModelHospitals = this.Mapper.Map<IndexViewModel>(resultModel);
            return this.View(viewModelHospitals);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var departments = this.hospitalsService.GetById(id).Departments;
            var departmentsResult = this.Mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            this.TempData["hospitalId"] = id;
            return this.View(departmentsResult);
        }

    }
}