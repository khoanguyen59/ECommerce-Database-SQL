namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Bills = new HashSet<Bill>();
            CreditCards = new HashSet<CreditCard>();
            Discounts = new HashSet<Discount>();
            EWallets = new HashSet<EWallet>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        [StringLength(50)]
        public string customer_mail { get; set; }

        [Required]
        [StringLength(20)]
        public string customer_fname { get; set; }

        [Required]
        [StringLength(20)]
        public string customer_lname { get; set; }

        [StringLength(9)]
        public string customer_pid { get; set; }

        [Required]
        [StringLength(10)]
        public string customer_phone { get; set; }

        [StringLength(20)]
        public string customer_city { get; set; }

        [StringLength(50)]
        public string customer_address { get; set; }

        [StringLength(10)]
        public string customer_postal_code { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditCard> CreditCards { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount> Discounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EWallet> EWallets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
