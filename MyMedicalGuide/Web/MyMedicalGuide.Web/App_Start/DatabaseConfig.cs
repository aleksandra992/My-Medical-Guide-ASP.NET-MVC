using MyMedicalGuide.Data;
using MyMedicalGuide.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MyMedicalGuide.Web.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyMedicalGuideDbContext, Configuration>());
            MyMedicalGuideDbContext.Create().Database.Initialize(true);
        }
    }
}