using System.Web;
using System.Web.Optimization;

namespace CLINICAMVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //usando bundles para las hojas de estilo
            bundles.Add(new StyleBundle("~/bundles/css")
            .Include(
            "~/Content/node_modules/font-awesome/css/font-awesome.min.css",
            "~/Content/node_modules/perfect-scrollbar/dist/css/perfect-scrollbar.min.css",
            "~/Content/node_modules/flag-icon-css/css/flag-icon.min.css",
            "~/Content/css/style.css",
            "~/Content/css/style-menu.css"));




            bundles.Add(new ScriptBundle("~/bundles/js")
            .Include(
            "~/Content/node_modules/jquery/dist/jquery.min.js",
            "~/Content/node_modules/popper.js/dist/umd/popper.min.js",
            "~/Content/node_modules/bootstrap/dist/js/bootstrap.min.js",
            "~/Content/node_modules/chart.js/dist/Chart.min.js",
            "~/Content/node_modules/perfect-scrollbar/dist/js/perfect-scrollbar.jquery.min.js",
            "~/Content/js/off-canvas.js",
            "~/Content/js/hoverable-collapse.js",
            "~/Content/js/misc.js",
            "~/Content/js/chart.js",
            "~/Content/js/maps.js"));
        }
    }
}
