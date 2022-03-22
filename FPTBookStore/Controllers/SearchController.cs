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
    public class SearchController : Controller
    {
        // GET: TimKiem
        FPTBook db = new FPTBook();
        [HttpPost]
        public ActionResult ResultSearch(FormCollection fc, int? _Page)
        {
            string Keyword = fc["txtTimkiem"].ToString().Trim();
            ViewBag.Keyword = Keyword;
            List<Book> lstBook = db.Books.Where(n => n.BookName.Contains(Keyword) && n.Quantity > 0).ToList();
            int pageNumber = (_Page ?? 1);
            int pageSize = 9;
            if (lstBook.Count == 0)
            {
                ViewBag.Notification = "The Book you requested was not found !";
                return View(db.Books.OrderBy(n => n.BookName).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Notification = "Found " + lstBook.Count.ToString() + " book:";
            return View(lstBook.OrderBy(n => n.BookName).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ResultSearch(string _Keyword, int? _Page)
        {
            ViewBag.Keyword = _Keyword;
            List<Book> lstBook = db.Books.Where(n => n.BookName.Contains(_Keyword) && n.Quantity > 0).ToList();
            int pageNumber = (_Page ?? 1);
            int pageSize = 9;
            if (lstBook.Count == 0)
            {
                ViewBag.Notification = "The Book you requested was not found !";
                return View(db.Books.OrderBy(n => n.BookName).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Notification = "Found " + lstBook.Count.ToString() + " book :";
            return View(lstBook.OrderBy(n => n.BookName).ToPagedList(pageNumber, pageSize));
        }
    }
}