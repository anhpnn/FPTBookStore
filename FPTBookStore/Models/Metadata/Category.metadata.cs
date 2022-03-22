using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FPTBookStore.Models
{
    [MetadataTypeAttribute(typeof(CategoryMetadata))]
    public partial class Category//connect to Class ChuDe in Models
    {
        internal sealed class CategoryMetadata
        {
            [Key]
            public int CategoryID { get; set; }

            [Display(Name = "Category Name")]
            [Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50,ErrorMessage="{0} no more than 50 characters")]
            public string CategoryName { get; set; }
        }
    }
}