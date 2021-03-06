﻿using System.Web;
using System.Web.Optimization;

namespace EventHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/scripts/app/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                       "~/Scripts/underscore-min.js",
                       "~/Scripts/jquery.datetimepicker.js",
                       "~/Scripts/bootbox.min.js",
                       "~/Scripts/moment.min.js"));

            bundles.Add(new StyleBundle("~/Content/lib").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/jquery.datetimepicker.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"
                      ));

            bundles.Add(new StyleBundle("~/plugin/owlcarousel/css").Include(
                    "~/Plugins/owlcarousel/assets/owl.carousel.min.css",
                    "~/Plugins/owlcarousel/assets/owl.theme.default.css"
                ));

            bundles.Add(new ScriptBundle("~/plugin/owlcarousel/js").Include(
                    "~/Plugins/owlcarousel/owl.carousel.min.js"
                    
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
        }
    }
}
