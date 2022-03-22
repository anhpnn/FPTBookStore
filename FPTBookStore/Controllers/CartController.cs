using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookStore.Models;

namespace FPTBookStore.Controllers
{
    public class CartController : Controller
    {

        FPTBook db = new FPTBook();

        #region Cart
        public List<Cart> GetCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
            }
            return lstCart;
        }

        public ActionResult AddCart(int __BookID, string strURL)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == __BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> lstCart = GetCart();
            Cart _Cart = lstCart.Find(n => n._BookID == __BookID);
            if (_Cart == null)
            {
                _Cart = new Cart(__BookID);
                lstCart.Add(_Cart);
                return Redirect(strURL);
            }
            else
            {
                if (_Cart._Quantity < book.Quantity)
                {
                    _Cart._Quantity++;
                }
                return Redirect(strURL);
            }
        }

        public ActionResult UpdateCart(int __BookID, FormCollection fc)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == __BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> lstCart = GetCart();
            Cart cart = lstCart.SingleOrDefault(n => n._BookID == __BookID);
            if (cart != null)
            {
                int Quantity = Convert.ToInt32(fc["txtQuantity"].ToString());
                if (Quantity > 0)
                {
                    if (Quantity >= book.Quantity)
                    {
                        cart._Quantity = Convert.ToInt32(book.Quantity);
                    }
                    else
                    {
                        cart._Quantity = Quantity;
                    }
                }
                else
                {
                    lstCart.RemoveAll(n => n._BookID == __BookID);
                }
                if (lstCart.Count == 0)
                {
                    Session["Cart"] = null;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Cart");
                }
            }
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteCart(int __BookID)
        {
            Book book = db.Books.SingleOrDefault(n => n.BookID == __BookID);
            if (book == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Cart> lstCart = GetCart();
            Cart cart = lstCart.SingleOrDefault(n => n._BookID == __BookID);
            if (cart != null)
            {
                lstCart.RemoveAll(n => n._BookID == __BookID);
            }
            if (lstCart.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> lstCart = GetCart();
            return View(lstCart);
        }

        private int TotalQuantity()
        {
            int _TotalQuantity = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                _TotalQuantity = lstCart.Sum(n => n._Quantity);
            }
            return _TotalQuantity;
        }

        private double Total()
        {
            double _Total = 0;
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart != null)
            {
                _Total = lstCart.Sum(n => n._Total);
            }
            return _Total;
        }

        public ActionResult CartPartial()
        {
            ViewBag.TotalQuantity = TotalQuantity();
            return PartialView();
        }

        public ActionResult TotalCart()
        {
            if (Total() <= 0)
            {
                return PartialView();
            }
            ViewBag.Total = Total();
            return PartialView();
        }

        public ActionResult EditCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cart> lstCart = GetCart();
            return View(lstCart);
        }
        #endregion

        #region Order
        [HttpPost]
        public ActionResult Order()
        {
            if ((Session["Account"] == null) || (Session["Account"].ToString() == ""))
            {
                return RedirectToAction("Login", "User");
            }
            if (Session["Cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            Order dh = new Order();
            Customer kh = (Customer)Session["Account"];
            List<Cart> gh = GetCart();
            dh.CustomerID = kh.CustomerID;
            dh.Paid = Convert.ToInt32(Total());
            dh.OrderStatus = 0;
            dh.OrderDay = DateTime.Now;
            dh.DeliveryDay = DateTime.Now;
            db.Orders.Add(dh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                OrderDetail orderdetail = new OrderDetail();
                orderdetail.OrderID = dh.OrderID;
                orderdetail.BookID = item._BookID;
                orderdetail.Quantity = item._Quantity;
                orderdetail.Price = item._Price.ToString();
                db.OrderDetails.Add(orderdetail);

                Book book = db.Books.SingleOrDefault(n => n.BookID == item._BookID);
                book.Quantity -= item._Quantity;
            }
            db.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Bill()
        {
            if ((Session["Account"] == null) || (Session["Account"].ToString() == ""))
            {
                return RedirectToAction("Login", "User");
            }
            if (Session["Cart"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            List<Cart> lstCart = GetCart();
            ViewBag.Customer = (Customer)Session["Account"];
            return View(lstCart);
        }
        #endregion
    }
}