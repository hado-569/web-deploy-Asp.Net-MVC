using System.Web;
using System.Web.Optimization;

namespace Store
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //JS

            bundles.Add(new ScriptBundle("~/bundles/jsMenu").Include(

                      "~/assests/client/js/jquery1.min.js",
                      "~/assests/client/js/megamenu.js"

                       ));

            bundles.Add(new ScriptBundle("~/bundles/jsSlider").Include(

                      "~/assests/client/js/jquery-ui.min.js",
                      "~/assests/client/js/css3-mediaqueries.js",
                      "~/assests/client/js/fwslider.js"
                      
                        ));
            

            bundles.Add(new ScriptBundle("~/bundles/jsController").Include(

                       "~/assests/client/js/Back_to_top.js",
                       "~/assests/client/js/jquery-ui.js"

                        ));
            bundles.Add(new ScriptBundle("~/bundles/jsEasydropdown").Include(

                     "~/assests/client/js/jquery.easydropdown.js"

                       ));

            //CSS

            bundles.Add(new StyleBundle("~/bundles/cssCore").Include(

                   "~/assests/client/css/style.css",
                   "~/assests/client/css/form.css",
                   "~/assests/client/css/fonts-googleapis.css",
                   "~/assests/client/css/back_to_top.css",
                   "~/assests/client/css/jquery-ui.css"
                   
                     ));
            bundles.Add(new StyleBundle("~/bundles/cssMenu").Include(

                      "~/assests/client/css/megamenu.css"
                      
                      ));
            bundles.Add(new StyleBundle("~/bundles/cssSlider").Include(

                      "~/assests/client/css/fwslider.css"

                      ));


            BundleTable.EnableOptimizations=true;

        }
    }
}
