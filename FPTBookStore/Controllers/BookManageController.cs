using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace FPTBookStore.Controllers
{
    public class BookManageController : Controller
    {
        // GET: Category Manage
        FPTBook db = new FPTBook();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.Books.ToList().OrderBy(n => n.BookID).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.CategoryName), "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNew(Book _Book, HttpPostedFileBase FileUpload)
        {
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.CategoryName), "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName");
            if (FileUpload == null)
            {
                ViewBag.Notification = "Cover Image not selected yet!";
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View(_Book);
            }
            var FileName = Path.GetFileName(FileUpload.FileName);
            var Link = Path.Combine(Server.MapPath("~/ImageBook"), FileName);
            if (!System.IO.File.Exists(Link))
            {
                FileUpload.SaveAs(Link);
            }
            _Book.CoverImage = FileUpload.FileName;
            _Book.UpdateDay = DateTime.Now;
            db.Books.Add(_Book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int _BookID)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == _BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.CategoryName), "CategoryID", "CategoryName", book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Book _Book, HttpPostedFileBase FileUpload)
        {
            ViewBag.CategoryID = new SelectList(db.Categories.ToList().OrderBy(n => n.CategoryName), "CategoryID", "CategoryName", _Book.CategoryID);
            ViewBag.PublisherID = new SelectList(db.Publishers.ToList().OrderBy(n => n.PublisherName), "PublisherID", "PublisherName", _Book.PublisherID);
            if (FileUpload == null)
            {
                ViewBag.Notification = "Cover Image not selected yet!";
                return View(_Book);
            }
            if (!ModelState.IsValid)
            {
                return View(_Book);
            }
            var FileName = Path.GetFileName(FileUpload.FileName);
            var Link = Path.Combine(Server.MapPath("~/ImageBook"), FileName);
            if (!System.IO.File.Exists(Link))
            {
                FileUpload.SaveAs(Link);
            }
            _Book.CoverImage = FileUpload.FileName;
            db.Entry(_Book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int _BookID)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == _BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int _BookID)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == _BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult ConfirmDelete(int _BookID)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == _BookID);
            List<OrderDetail> lstOrderDetail = db.OrderDetails.Where(n => n.BookID == _BookID).ToList();
            if ((book == null) || (lstOrderDetail.Count > 0))
            {
                if (book == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstOrderDetail.Count > 0)
                {
                    return View(book);
                }
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}