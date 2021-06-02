using System.Web;
using System.Web.Optimization;

namespace MovieRentalWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libraries").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/toastr.js"
                        //this library will be used for listing data 
                        // "~/scripts/datatables/jquery.datatables.js",
                        //"~/scripts/datatables/datatables.bootstrap.js",
                        ));            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));            

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      //this library will be used for listing data 
                      //"~/content/datatables/css/datatables.bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/TypeaheadStyleSheet.css",
                      "~/Content/toastr.css",
                      "~/content/CustomerrorStyleSheet.css"
                      ));
        }
    }
}
