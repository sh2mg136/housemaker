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
            ViewBag.Title = "Начало";
            return View();
        }

        public ActionResult TestAction1()
        {
            ViewBag.Title = "Проверка - 1";
            return View();
        }

        public ActionResult MenuTest()
        {
            ViewBag.Title = "Тестирование меню";
            return View();
        }

        public ActionResult SideMenu()
        {
            ViewBag.Title = "SideMenu";

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
                              orderby m.SortOrder
                              select new Models.MenuListItem
                              {
                                  Id = m.M_ID,
                                  ParentId = m.M_P_ID,
                                  Name = m.M_NAME,
                                  ControllerName = m.CONTROLLER_NAME,
                                  ActionName = m.ACTION_NAME,
                                  CssClass = m.CSS_CLASS,
                                  HasChilds = false,
                                  IsRootElement = false,
                                  SortOrder = m.SortOrder
                              })
                              .Distinct()
                              .ToList();

                var childs = result.Where(x => x.Id > 1 && x.ParentId > 1).ToList();

                foreach (var m in result)
                {
                    m.HasChilds = childs.Where(x => x.ParentId == m.Id).Count() > 0;
                    m.IsRootElement = !m.HasChilds && m.ParentId <= 1;
                }

                var menu = result.Where(x => x.Id > 1).OrderBy(x => x.SortOrder).Distinct().ToList();

                return PartialView("Menu", menu);
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
