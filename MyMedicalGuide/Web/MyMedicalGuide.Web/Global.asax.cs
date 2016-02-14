namespace MyMedicalGuide.Web
{
    using Infrastructure.Constants;
    using Infrastructure.Mapping;
    using MyMedicalGuide.Web.App_Start;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            AutofacConfig.RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DatabaseConfig.Initialize();


            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.Load(AssemblyConst.WebModels));
        }
    }
}
