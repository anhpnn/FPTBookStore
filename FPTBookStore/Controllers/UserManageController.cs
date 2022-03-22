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
    public class UserManageController : Controller
    {
        // GET: QuanLyNhanSu
        FPTBook db = new FPTBook();
        public ActionResult Index(int? _Page)
        {
            int PageNumber = (_Page ?? 1);
            int PageSize = 10;
            return View(db.Customers.ToList().OrderBy(n => n.CustomerID).ToPagedList(PageNumber, PageSize));
        }

        [HttpGet]
        public ActionResult Edit(int _CusID)
        {
            Customer customer = db.Customers.SingleOrDefault(n => n.CustomerID == _CusID);
            if (customer == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Customer _customer)
        {
            if (!ModelState.IsValid)
            {
                return View(_customer);
            }
            db.Entry(_customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View(int _CusID)
        {
            Customer customer = db.Customers.SingleOrDefault(n => n.CustomerID == _CusID);
            if (customer == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(int _CusID)
        {
            Customer customer = db.Customers.SingleOrDefault(n => n.CustomerID == _CusID);
            if (customer == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        public ActionResult ConfirmDelete(int _CusID)
        {
            Customer customer = db.Customers.SingleOrDefault(n => n.CustomerID == _CusID);
            List<Order> lstCart = db.Orders.Where(n => n.CustomerID == _CusID).ToList();
            if ((customer == null) || (lstCart.Count > 0) || (_CusID == 1))
            {
                if (customer == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                if ((lstCart.Count > 0) || (_CusID == 1))
                {
                    return View(customer);
                }
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}