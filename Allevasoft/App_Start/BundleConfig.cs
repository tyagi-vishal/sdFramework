using System.Web;
using System.Web.Optimization;

namespace Allevasoft
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/js/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap.js",
                      "~/Scripts/js/respond.js",
                      "~/Scripts/js/tutorial.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/FontAwesome/css").Include("~/fonts/font-awesome/css/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/site").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/master").Include("~/Content/master.css"));
            bundles.Add(new StyleBundle("~/Content/media-sud").Include("~/Content/media-sud.css"));
            bundles.Add(new StyleBundle("~/Content/media").Include("~/Content/media.css"));
            bundles.Add(new StyleBundle("~/Content/selectric").Include("~/Content/selectric.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrapmin").Include("~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/animate").Include("~/Content/animate.min.css"));
            bundles.Add(new StyleBundle("~/Content/mCustomScrollbar").Include("~/Content/jquery.mCustomScrollbar.css"));

            //Load Scripts Files

            bundles.Add(new ScriptBundle("~/bundles/angularJs").Include("~/Scripts/js/angular.js"));
            bundles.Add(new ScriptBundle("~/bundles/tutorial").Include("~/Scripts/js/tutorial.js"));
            bundles.Add(new StyleBundle("~/bundles/mCustomScrollbarJs").Include("~/Scripts/js/jquery.mCustomScrollbar.concat.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/easyResponsiveTabs").Include("~/Scripts/js/easyResponsiveTabs.js"));
            bundles.Add(new StyleBundle("~/bundles/selectricJS").Include("~/Scripts/js/jquery.selectric.min.js"));
            
            //Load Common Scripts Files

            bundles.Add(new ScriptBundle("~/bundles/allevaApp").Include("~/Scripts/pageScripts/allevaApp.js",
                "~/Scripts/pageScripts/allevaFactory.js",
                "~/Scripts/pageScripts/allevaService.js", 
                "~/Scripts/pageScripts/Common/commonUrl.js"));
          
            //Load Design Scripts Files

            bundles.Add(new StyleBundle("~/bundles/allevaLayout").Include("~/Scripts/DesignJs/allevaLayout.js"));

            //Page Scripts

        }
    }
}
