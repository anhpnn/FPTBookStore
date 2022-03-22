using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;

namespace FPTBookStore.Controllers
{
    public class BookController : Controller
    {
        // GET: Sach
        FPTBook db = new FPTBook();
        public PartialViewResult NewBookPartial()
        {
            var lstNewBook = db.Books.Where(n => n.Quantity > 0).Take(3).ToList();
            return PartialView(lstNewBook);
        }

        public ViewResult ViewDetail(int _BookID = 0)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == _BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.CategoryName = db.Categories.Single(n => n.CategoryID == book.CategoryID).CategoryName;
            ViewBag.PublisherName = db.Publishers.Single(n => n.PublisherID == book.PublisherID).PublisherName;
            return View(book);
        }
    }
}