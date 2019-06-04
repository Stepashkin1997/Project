using System.Web;
using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        , "~/Scripts/Script.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Style.css"));
        }
    }
}
