using System.Web;
using System.Web.Optimization;

namespace MyMedicalGuide.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/home").Include(
                        "~/Scripts/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                        "~/Scripts/kendo/kendo.all.min.js",
                        "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                       "~/Content/kendo/kendo.nova.min.css",
                       "~/Content/kendo/kendo.common-nova.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/JqueryUICss").Include(
                "~/Scripts/jquery-ui.css",
                "~/Scripts/jquery-ui.structure.css",
                "~/Scripts/jquery-ui.theme.css"
                ));
            bundles.Add(new StyleBundle("~/Content/Alert").Include(
                "~/Content/sweetalert.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui")
                .Include("~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/Alert")
               .Include("~/Scripts/sweetalert.min.js"));




        }
    }
}
