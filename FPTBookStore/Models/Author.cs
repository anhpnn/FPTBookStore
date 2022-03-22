namespace FPTBookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Author")]
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            Embarks = new HashSet<Embark>();
        }

        public int AuthorID { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public string Story { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Embark> Embarks { get; set; }
    }
}
