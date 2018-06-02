using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace housemaker.Controllers
{
    public class BookController : Controller
    {

        Repository.IRepository _repo;

        public BookController(Repository.IRepository repo)
        {
            _repo = repo;
        }

        // GET: Book
        public ActionResult Index()
        {
            var books = _repo.List();

            var bks = books.ToList();

            return View(bks);
        }
    }
}