using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Web.Mvc.Html;

namespace themesite.Helpers
{

    public static class HtmlExtensions
    {
        /*
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header"><i class="fa fa-laptop"></i> Dashboard</h3>
                    <ol class="breadcrumb">
                        @{foreach (var item in Model)
                            {
                                <li><i class="fa fa-home"></i><a href="index.html">Home</a></li>
                                <li><i class="fa fa-laptop"></i>Dashboard</li>
                            }
                        }
                    </ol>
                </div>
            </div>
        */

        public static MvcHtmlString BuildBreadcrumbNavigation(this HtmlHelper html)
        {
            string controllerName = html.ViewContext.RouteData.Values["controller"].ToString();
            string actionName = html.ViewContext.RouteData.Values["action"].ToString();
            string title = null;
            var vb = html.ViewContext.ViewBag;
            if (vb != null)
            {
                title = vb.Title;
            }


            TagBuilder div = new TagBuilder("div");

            TagBuilder h = new TagBuilder("h3");
            h.AddCssClass("page-header");

            TagBuilder i = new TagBuilder("i");
            i.AddCssClass("fa fa-laptop");

            h.InnerHtml += i.ToString();

            div.InnerHtml += h.ToString();

            TagBuilder ol = new TagBuilder("ol");
            ol.AddCssClass("breadcrumb");

            TagBuilder li = new TagBuilder("li");
            li.InnerHtml += html.ActionLink(controllerName, "Index");
            ol.InnerHtml += li.ToString();

            li = new TagBuilder("li");
            li.InnerHtml += title ?? actionName;
            ol.InnerHtml += li.ToString();

            div.InnerHtml += ol.ToString();

            return new MvcHtmlString(div.ToString());
        }
    }
}
