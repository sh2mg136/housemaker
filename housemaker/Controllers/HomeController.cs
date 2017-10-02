using housemaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace housemaker.Controllers
{
    public class HomeController : Controller
    {

        private SqlDbContext db = new SqlDbContext();

        public ActionResult Index()
        {
            var photos = db.Photos.ToList();
            var model = new HomeViewModel()
            {
                PhotosCount = photos.Count(),
                Photos = photos.OrderByDescending(x => x.Id)
            };
            return View(model);
        }

        public ActionResult Album()
        {
            ViewBag.Message = "Фотоальбом";
            var photos = db.Photos.ToList();
            var model = new HomeViewModel()
            {
                Photos = photos
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult CarouselPartial()
        {
            return View(db.Photos.ToList());
        }

    }


    public class HomeViewModel
    {
        public int PhotosCount { get; set; }
        public IEnumerable<Models.CarouselItem> Photos { get; set; }
    }

}