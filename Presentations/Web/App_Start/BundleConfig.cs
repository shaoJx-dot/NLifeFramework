using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Plugin/jquery/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/Plugin/bootstrap/bootstrap.min.js",
                        "~/Scripts/Plugin/bootstrap/respond.min.js",
                        "~/Scripts/Plugin/Loading/modernizr.js",
                        "~/Scripts/Plugin/Loading/pace.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Loading").Include(
                        "~/Scripts/Plugin/Loading/main.js"));
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.min.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.min.css",
                      "~/Content/Css/style.css",
                      "~/Content/Css/main.css",
                      "~/Content/Css/masonry.css"));

            bundles.Add(new StyleBundle("~/Content/case").Include(
                       "~/Content/Css/base.css",
                      "~/Content/Css/vendor.css"));
        }
    }
}
