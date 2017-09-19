using System.Web.Optimization;

namespace LoanCalculator
 
{
    public class BoundlesConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-yeti.css",
                "~/Content/site.css"));
        }
    }
}