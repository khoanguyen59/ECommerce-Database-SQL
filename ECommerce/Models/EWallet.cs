namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EWallet")]
    public partial class EWallet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EWallet()
        {
            Bills = new HashSet<Bill>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ewallet_customer_mail { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ewallet_name { get; set; }

        [Required]
        [StringLength(10)]
        public string ewallet_linked_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
