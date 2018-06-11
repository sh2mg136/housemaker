using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace themesite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Начало";

            return View();
        }

        public ActionResult Wellcome()
        {
            ViewBag.Message = "Добро пожаловать";

            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Панель управления";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "О сервисе";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(Models.ContactMailModel model)
        {
            ViewBag.Message = "Отправка Email.";

            model.HasError = false;

            var ms = ModelState.FirstOrDefault();

            if (ModelState.IsValid)
            {
                var subj = model.Subject ?? "Сообщение с формы обратной связи ";

                if (!string.IsNullOrWhiteSpace(model.Name))
                {
                    subj += " от" + model.Name;
                }

                Helpers.EmailHelper helper = new Helpers.EmailHelper();

                model.HasError = true;
                model.ErrorMessage = string.Empty;

                var resp = helper.SendEmail("admin@redexsrv.ru",
                    model.Email,
                    subj,
                    model.Message);

                if (resp.HasError)
                {
                    model.HasError = true;
                    model.ErrorMessage = resp.ErrorMessage;
                }
            }
            else
            {
                model.HasError = true;
                model.ErrorMessage = "Ошибка отправки сообщения. ";
                model.ErrorMessage += ms.Value;
            }

            return View(model);

        }

    }
}