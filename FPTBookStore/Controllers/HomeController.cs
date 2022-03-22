using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;
using PagedList;
using PagedList.Mvc;

namespace FPTBookStore.Controllers
{
    public class HomeController : Controller
    {
        FPTBook db = new FPTBook();

        public ActionResult Index(int? _Page)
        {
            int PageSize = 9;
            int PageNumber = (_Page ?? 1);
            return View(db.Books.Where(n => n.Quantity > 0).OrderBy(n => n.BookID).ToPagedList(PageNumber, PageSize));
        }

        public PartialViewResult NewBookPartial()
        {
            var lstNewBook = db.Books.Take(15).ToList();
            return PartialView(lstNewBook);
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
    }
}