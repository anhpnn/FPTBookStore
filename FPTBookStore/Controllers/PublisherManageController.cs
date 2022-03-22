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
    public class PublisherManageController : Controller
    {
        // GET: Publisher Manage
        FPTBook db = new FPTBook();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.Publishers.ToList().OrderBy(n => n.PublisherID).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNew(Publisher _publisher)
        {
            db.Publishers.Add(_publisher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int _PubID)
        {
            Publisher publisher = db.Publishers.SingleOrDefault(n => n.PublisherID == _PubID);
            if (publisher == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(publisher);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Publisher _publisher)
        {
            if (!ModelState.IsValid)
            {
                return View(_publisher);
            }
            db.Entry(_publisher).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int _PubID)
        {
            Publisher publisher = db.Publishers.SingleOrDefault(n => n.PublisherID == _PubID);
            if (publisher == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult ConfirmDelete(int _PubID)
        {
            Publisher publisher = db.Publishers.SingleOrDefault(n => n.PublisherID == _PubID);
            List<Book> lstBook = db.Books.Where(n => n.PublisherID == _PubID).ToList();
            if ((publisher == null) || (lstBook.Count > 0))
            {
                if (publisher == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstBook.Count > 0)
                {
                    return View(publisher);
                }
            }
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int _PubID)
        {
            Publisher publisher = db.Publishers.SingleOrDefault(n => n.PublisherID == _PubID);
            if (publisher == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(publisher);
        }
    }
}