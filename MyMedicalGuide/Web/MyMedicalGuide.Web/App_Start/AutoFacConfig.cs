using Autofac;
using Autofac.Integration.Mvc;
using MyMedicalGuide.Data;
using MyMedicalGuide.Data.Repositories;
using MyMedicalGuide.Services.Contracts;
using MyMedicalGuide.Services.Web;
using MyMedicalGuide.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyMedicalGuide.Web.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new MyMedicalGuideDbContext())
                .As<IMyMedicalGuideDbContext>()
                .InstancePerRequest();
            builder.Register(x => new HttpCacheService())
                .As<ICacheService>()
                .InstancePerRequest();
            builder.Register(x => new IdentifierProvider())
                .As<IIdentifierProvider>()
                .InstancePerRequest();

            var servicesAssembly = Assembly.GetAssembly(typeof(IPatientService));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(EfGenericRepository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();
        }
    }
}