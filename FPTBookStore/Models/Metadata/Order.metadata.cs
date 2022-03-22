using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FPTBookStore.Models
{
    [MetadataTypeAttribute(typeof(OrderMetadata))]
    public partial class Order
    {
        internal sealed class OrderMetadata
        {
            [Display(Name = "Order ID")]
            [Key]
            public int OrderID { get; set; }

            [Display(Name = "Total")]
            [DisplayFormat(DataFormatString = "{0:#,##0 $}")]
            public int? Paid { get; set; }

            [Display(Name = "Status")]
            [Range(0, 1, ErrorMessage = "{0} Must [0, 1] 0: Unfinished, 1: Finished")]
            public int? OrderStatus { get; set; }

            [Display(Name = "Order Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? OrderDay { get; set; }

            [Display(Name = "Delivery Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? DeliveryDay { get; set; }

            [Display(Name = "Customer ID")]
            public int? CustomerID { get; set; }
        }
    }
}