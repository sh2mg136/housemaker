using System.Web;
using System.Web.Optimization;

namespace themesite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui-1.10.4.min.js",
                        "~/Scripts/jquery-1.8.3.min.js",
                        "~/Scripts/jquery-ui-1.9.2.custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.css",
                      "~/Content/elegant-icons-style.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-fullcalendar.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/jquery-jvectormap-1.2.2.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/widgets.css",
                      "~/Content/style.css",
                      "~/Content/style-responsive.css",
                      "~/Content/xcharts.min.css",
                      "~/Content/jquery-ui-1.10.4.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/assets/css").Include(
                "~/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css",
                "~/assets/fullcalendar/fullcalendar/fullcalendar.css",
                "~/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css"));

        }
    }
}
