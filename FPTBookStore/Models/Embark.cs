namespace FPTBookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Embark")]
    public partial class Embark
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorID { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string Postion { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book Book { get; set; }
    }
}
