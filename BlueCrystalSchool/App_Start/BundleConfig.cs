using System.Web.Optimization;

namespace BlueCrystalSchool
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
              
                "~/Scripts/js/plugins/metisMenu/jquery.metisMenu.js",
                "~/Scripts/js/plugins/slimscroll/jquery.slimscroll.min.js",
               
                "~/Scripts/js/inspinia.js",
                "~/Scripts/js/plugins/pace/pace.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/applicationplugins").Include(
             //  "~/Scripts/js/plugins/jquery-ui/jquery-ui.min.js",
               "~/Scripts/js/plugins/dataTables/datatables.min.js"
               , "~/Scripts/js/plugins/select2/select2.full.min.js"
            //"~/Scripts/js/plugins/flot/jquery.flot.js",
            // "~/Scripts/js/plugins/flot/jquery.flot.tooltip.min.js",
            // "~/Scripts/js/plugins/flot/jquery.flot.spline.js",
            // "~/Scripts/js/plugins/flot/jquery.flot.resize.js",
            // "~/Scripts/js/plugins/flot/jquery.flot.pie.js",
            // "~/Scripts/js/plugins/peity/jquery.peity.min.js",
            // "~/Scripts/js/demo/peity-demo.js", /********** To Be Removes Later *************************/


            // "~/Scripts/js/plugins/gritter/jquery.gritter.min.js",
            // "~/Scripts/js/plugins/sparkline/jquery.sparkline.min.js",
            // "~/Scripts/js/demo/sparkline-demo.js", /********** To Be Removes Later *************************/
            // "~/Scripts/js/plugins/chartJs/Chart.min.js",
            // "~/Scripts/js/plugins/toastr/toastr.min.js"
            ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css"
                //,"~/Content/css/bootstrap.min.css"
                ,"~/Content/font-awesome/css/font-awesome.css"
                ,"~/Content/css/plugins/dataTables/datatables.min.css"
                , "~/Content/css/plugins/select2/select2.min.css"
                , "~/Content/css/animate.css"
                ,"~/Content/css/style.css"
                ,"~/Content/site.css"
                ));
        }
    }
}