using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FPTBookStore.Models
{
        [MetadataTypeAttribute(typeof(PublisherMetadata))]
    public partial class Publisher
    {
        internal sealed class PublisherMetadata
        {
            [Key]
            public int PublisherID { get; set; }

            [Display(Name = "Publisher Name")]
            [Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50,ErrorMessage="{0} no more than 50 characters")]
            public string PublisherName { get; set; }

            [Display(Name = "Address")]
            [Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(200,ErrorMessage="{0} no more than 200 characters")]
            public string Address { get; set; }

            [Display(Name = "Phone")]
            [Required(ErrorMessage = "{0} can't be left blank")]
            [StringLength(50,ErrorMessage="{0} no more than 50 chracters")]
            public string Phone { get; set; }
        }
    }
}