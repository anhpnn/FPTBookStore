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
    public class OrderManageController : Controller
    {
        // GET: Order Manage
        FPTBook db = new FPTBook();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.Orders.ToList().OrderBy(n => n.OrderID).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        public ActionResult Edit(int _OrderID)
        {
            Order order = db.Orders.SingleOrDefault(n => n.OrderID == _OrderID);
            if (order == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(order);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Order _order)
        {
            if (!ModelState.IsValid)
            {
                return View(_order);
            }
            db.Entry(_order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}