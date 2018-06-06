using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace themesite.Controllers
{
    public class TestController : Controller
    {

        u0506100_redexsrvdbEntities objEntity = new u0506100_redexsrvdbEntities();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTest()
        {
            return View();
        }

        public ActionResult SideMenu()
        {
            List<Models.MenuItem> list = new List<Models.MenuItem>
            {
                new Models.MenuItem { Link = "/Test/Index", LinkName = "Home" },
                new Models.MenuItem { Link = "/Test/Login", LinkName = "Login" },
                new Models.MenuItem { Link = "/Test/Registration", LinkName = "Register" }
            };
            return PartialView("SideMenu", list);
        }

        public ActionResult GetMenuList()
        {
            try
            {

                var result = (from m in objEntity.MenuTree
                              select new Models.MenuListItem
                              {
                                  Id = m.M_ID,
                                  ParentId = m.M_P_ID,
                                  Name = m.M_NAME,
                                  ControllerName = m.CONTROLLER_NAME,
                                  ActionName = m.ACTION_NAME,
                                  CssClass = m.CSS_CLASS
                              }).ToList();

                return PartialView("Menu", result.Where(x => x.Id > 0).Distinct());
            }
            catch (Exception ex)
            {
                var error = ex.Message.ToString();
                return Content(@"Error

<div> " + error + "" +
"</div>");

            }

        }

    }

}
