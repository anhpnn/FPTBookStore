using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FPTBookStore.Models
{
    [MetadataTypeAttribute(typeof(CustomerMetadata))]
    public partial class Customer
    {
        internal sealed class CustomerMetadata
        {
            [Key]
            public int CustomerID { get; set; }

            [Display(Name = "Full Name")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50, ErrorMessage = "{0} no more than 50 characters")]
            public string Fullname { get; set; }

            [Display(Name = "Account")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50, ErrorMessage = "{0} no more than 50 characters")]
            public string Account { get; set; }

            [Display(Name = "Password")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50, ErrorMessage = "{0} no more than 50 characters")]
            public string Password { get; set; }

            [Display(Name = "Email")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(100, ErrorMessage = "{0} no more than 50 characters")]
            [RegularExpression(@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "{0} Incorrect")]
            public string Email { get; set; }

            [Display(Name = "Address")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(200, ErrorMessage = "{0} no more than 200 characters")]
            public string Address { get; set; }

            [Display(Name = "Phone")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50, ErrorMessage = "{0} no more than 50 characters")]
            public string Phone { get; set; }

            [Display(Name = "Gender")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(5, ErrorMessage = "{0} no more than 5 characters")]
            public string Gender { get; set; }

            [Display(Name = "Birth Date")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? Birthday { get; set; }

            [Display(Name = "Position")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [Range(0, 1, ErrorMessage = "{0} must [0, 1] 0: Customer, 1: Admin")]
            public int Position { get; set; }
        }
    }
}