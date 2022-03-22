using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;

namespace FPTBookStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: ChuDe
        FPTBook db = new FPTBook();
        public ActionResult CategoryPartial()
        {
            return PartialView(db.Categories.Take(3).ToList());
        }

        public ViewResult ThemedBook(int _CateID=0)
        {
            Category cate=db.Categories.SingleOrDefault(n=>n.CategoryID==_CateID);
            if(cate==null)
            {
                Response.StatusCode=404;
                return View();
            }
            List<Book> lstBook = db.Books.Where(n => n.CategoryID == _CateID && n.Quantity > 0).OrderBy(n => n.Price).ToList();
            if(lstBook.Count==0)
            {
                ViewBag.Book = "There are no Books in this Category!";
            }
            return View(lstBook);
        }

        public ViewResult ListCategory()
        {
            return View(db.Categories.ToList());
        }
    }
}