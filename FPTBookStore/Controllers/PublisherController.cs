using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;

namespace FPTBookStore.Controllers
{
    public class PublisherController : Controller
    {
        
        FPTBook db = new FPTBook();
        public PartialViewResult PublisherPartial()
        {
            return PartialView(db.Publishers.Take(5).OrderBy(publisher => publisher.PublisherID).ToList());
        }

        public ViewResult BookByPublisher(int _PubID)
        {
            Publisher publisher = db.Publishers.SingleOrDefault(n => n.PublisherID == _PubID);
            if (publisher == null)
            {
                Response.StatusCode = 404;
                return View();
            }
            List<Book> lstBook = db.Books.Where(n => n.PublisherID == _PubID && n.Quantity > 0).OrderBy(n => n.Price).ToList();
            if (lstBook.Count == 0)
            {
                ViewBag.Book = "This Publisher's Books are not available!";
            }
            return View(lstBook);
        }

        public ViewResult ListPublisher()
        {
            return View(db.Publishers.ToList());
        }
    }
}