using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTBookStore.Models
{
    public class Cart
    {
        FPTBook db = new FPTBook();
        public int _BookID { get; set; }
        public string _BookName { get; set; }
        public string _CoverImage { get; set; }
        public double _Price { get; set; }
        public int _Quantity { get; set; }
        public double _Total
        {
            get { return _Quantity * _Price; }
        }
        public Cart(int __BookID)
        {
            _BookID = __BookID;
            Book book = db.Books.Single(n => n.BookID == _BookID);
            _BookName = book.BookName;
            _CoverImage = book.CoverImage;
            _Price = Convert.ToDouble(book.Price);
            _Quantity = 1;
        }
    }
}