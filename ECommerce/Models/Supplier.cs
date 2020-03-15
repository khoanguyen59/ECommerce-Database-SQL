namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(50)]
        public string supplier_mail { get; set; }

        [Required]
        [StringLength(20)]
        public string supplier_fname { get; set; }

        [Required]
        [StringLength(20)]
        public string supllier_lname { get; set; }

        [StringLength(9)]
        public string supplier_pid { get; set; }

        [Required]
        [StringLength(10)]
        public string supplier_phone { get; set; }

        [StringLength(20)]
        public string supplier_city { get; set; }

        [Required]
        [StringLength(50)]
        public string supplier_address { get; set; }

        [Required]
        [StringLength(30)]
        public string supplier_company { get; set; }

        [StringLength(10)]
        public string supplier_BRC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
