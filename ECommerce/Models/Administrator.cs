namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Administrator()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [StringLength(50)]
        public string admin_mail { get; set; }

        [Required]
        [StringLength(20)]
        public string admin_fname { get; set; }

        [Required]
        [StringLength(20)]
        public string admin_lname { get; set; }

        [StringLength(10)]
        public string admin_phone { get; set; }

        [StringLength(20)]
        public string admin_city { get; set; }

        [Required]
        [StringLength(16)]
        public string admin_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
