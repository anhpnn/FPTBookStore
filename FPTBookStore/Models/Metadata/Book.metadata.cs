using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;//for Metadata
using System.ComponentModel.DataAnnotations;

namespace FPTBookStore.Models
{
    [MetadataTypeAttribute(typeof(BookMetadata))]
    public partial class Book
    {
        internal sealed class BookMetadata
        {
            [Key]
            public int BookID { get; set; }

            [Display(Name = "Book Name")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50, ErrorMessage = "{0} no more than 50 characters")]
            public string BookName { get; set; }

            [Display(Name = "Price")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [Range(0, 1000, ErrorMessage = "{0} must be [0, 1.000]")]
            [DisplayFormat(DataFormatString = "{0:#,##0 $}")]
            public decimal? Price { get; set; }

            [Display(Name = "Description")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            public string Details { get; set; }

            [Display(Name = "Cover Image")]
            [StringLength(50, ErrorMessage = "{0} no more than 50 characters")]
            public string CoverImage { get; set; }

            [Display(Name = "Date updated")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            [DataType(DataType.Date)]
            public DateTime? UpdateDay { get; set; }

            [Display(Name = "Quantity")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [Range(0, 1000, ErrorMessage = "{0} must be [0, 1.000]")]
            [DisplayFormat(DataFormatString = "{0:#,##0}")]
            public int? Quantity { get; set; }

            [Display(Name = "Publisher")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            public int? PublisherID { get; set; }

            [Display(Name = "Category")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            public int? CategoryID { get; set; }

            [Display(Name = "Status")]
            //[Required(ErrorMessage = "{0} can't be left blank")]
            [Range(0, 1, ErrorMessage = "{0}must be [0, 1] 0: Out Stocking, 1: Stocking")]
            public int? BookStatus { get; set; }
        }
    }
}