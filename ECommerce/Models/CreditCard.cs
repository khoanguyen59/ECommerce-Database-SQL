namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CreditCard")]
    public partial class CreditCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CreditCard()
        {
            Bills = new HashSet<Bill>();
        }

        [Required]
        [StringLength(50)]
        public string credit_card_customer_mail { get; set; }

        [Key]
        [StringLength(16)]
        public string credit_card_id { get; set; }

        [Required]
        [StringLength(20)]
        public string credit_card_bank { get; set; }

        [Column(TypeName = "date")]
        public DateTime credit_card_expdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
