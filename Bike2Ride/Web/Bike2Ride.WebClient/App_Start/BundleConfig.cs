using System.Web;
using System.Web.Optimization;

namespace Bike2Ride.WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize.min.js",
                      "~/Scripts/init.js"));

            bundles.Add(new ScriptBundle("~/bundles/map").Include(
                "~/Scripts/map-markers.js"));

            bundles.Add(new ScriptBundle("~/bundles/map-edit").Include(
                "~/Scripts/map-edit.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/map").Include(
                "~/Content/map.css"));

            bundles.Add(new StyleBundle("~/Content/footer").Include(
                "~/Content/footer.css"));

            bundles.Add(new StyleBundle("~/Content/404").Include(
                "~/Content/404.css"));
        }
    }
}
