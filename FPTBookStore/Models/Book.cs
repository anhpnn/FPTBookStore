namespace FPTBookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Embarks = new HashSet<Embark>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Display(Name="Book ID")]
        public int BookID { get; set; }

        [Display(Name = "Book Name")]
        [StringLength(50)]
        public string BookName { get; set; }

        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Display(Name = "Description")]
        public string Details { get; set; }

        [Display(Name = "Cover Image")]
        [StringLength(50)]
        public string CoverImage { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdateDay { get; set; }

        [Display(Name = "Quantity Stock")]
        public int? Quantity { get; set; }

        [Display(Name = "Publisher")]
        public int? PublisherID { get; set; }

        [Display(Name = "Category")]
        public int? CategoryID { get; set; }

        [Display(Name = "Status")]
        public int? BookStatus { get; set; }

        public virtual Category Category { get; set; }

        public virtual Publisher Publisher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Embark> Embarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
