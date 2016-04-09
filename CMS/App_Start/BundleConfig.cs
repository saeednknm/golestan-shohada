using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace CMS.AppStart
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundle/validation").Include("~/Design/Js/jquery.validationEngine.js", "~/Design/Js/jquery.validationEngine-fa.js"));

            bundles.Add(new ScriptBundle("~/bundle/query").Include("~/Design/Js/jquery-1.11.0.js", "~/Design/Js/bootstrap.js", "~/Design/Js/validation.js"
               
                , "~/Design/Js/jquery.maskedinput.js","~/Design/Js/jquery.nicescroll.js","~/Js/sb-admin-2.js", "~/Design/Js/metisMenu.js" ,"~/Design/Js/jquery.blockUI.js"
               , "~/Design/Js/thickbox.js", "~/Design/Js/modernizr-*"
                 ));
          //  bundles.Add(new StyleBundle("~/Content/css").Include("~/Design/Style/bootstrap.min.css", "~/Design/Style/thickbox.css", "~/Design/Style/validationEngine.jquery.css", "~/Design/Style/gridview.css", "~/Design/font-awesome-4.1.0/css/font-awesome.min.css", "~/Design/Style/sb-admin.css", "~/Design/Style/dist/metisMenu.min.css", "~/Design/Style/Grid.css", "~/Design/Style/custom.css"));
            //,,
                //
                //

        }
    }
}