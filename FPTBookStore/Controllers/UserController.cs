using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;

namespace FPTBookStore.Controllers
{
    public class UserController : Controller
    {
        // GET: NguoiDung
        FPTBook db = new FPTBook();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer _customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Customer customer = db.Customers.SingleOrDefault(n => n.Account == _customer.Account);
            if (customer != null)
            {
                ViewBag.Notification = "Username already exists";
                return View();
            }
            _customer.Position = 0;
            db.Customers.Add(_customer);
            db.SaveChanges();
            Session["Account"] = _customer;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string textAccount = fc["txtAccount"].ToString();
            string textPassword = fc["txtPassword"].ToString();
            Customer _customer = db.Customers.SingleOrDefault(n => n.Account == textAccount && n.Password == textPassword);
            if (_customer != null)
            {
                ViewBag.Notification = "Login successfull";
                Session["Account"] = _customer;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Notification = "Incorrect Account or Password";
            return View();
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
            return RedirectToAction("Index", "Home");
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

        public ActionResult UserPartial()
        {
            if ((Session["Account"] == null) || (Session["Account"].ToString() == ""))
            {
                return PartialView();
            }
            ViewBag.Customer = (Customer)Session["Account"];
            return PartialView();
        }

        public ActionResult LogOut()
        {
            if ((Session["Account"] == null) || (Session["Account"].ToString() == ""))
            {
                return RedirectToAction("Login", "User");
            }
            Session["Account"] = null;
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminUser()
        {
            if ((Session["Account"] == null) || (Session["Account"].ToString() == ""))
            {
                return PartialView();
            }
            ViewBag.Customer = (Customer)Session["Account"];
            return PartialView();
        }
    }
}