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
    public class CategoryManageController : Controller
    {
        //GET: QuanLyChuDe
        FPTBook db = new FPTBook();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.Categories.ToList().OrderBy(n => n.CategoryID).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNew(Category _Category)
        {
            db.Categories.Add(_Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int _CateID)
        {
            Category cate = db.Categories.SingleOrDefault(n => n.CategoryID == _CateID);
            if (cate == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cate);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Category _Category)
        {
            if (!ModelState.IsValid)
            {
                return View(_Category);
            }
            db.Entry(_Category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int _CateID)
        {
            Category cate = db.Categories.SingleOrDefault(n => n.CategoryID == _CateID);
            if (cate == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult ConfirmDelete(int _CateID)
        {
            Category cate = db.Categories.SingleOrDefault(n => n.CategoryID == _CateID);
            List<Book> lstBook = db.Books.Where(n => n.CategoryID == _CateID).ToList();
            if ((cate == null) || (lstBook.Count > 0))
            {
                if (cate == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if (lstBook.Count > 0)
                {
                    return View(cate);
                }
            }
            db.Categories.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}