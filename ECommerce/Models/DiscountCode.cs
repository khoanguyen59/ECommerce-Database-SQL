namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountCode")]
    public partial class DiscountCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscountCode()
        {
            Discounts = new HashSet<Discount>();
            DiscountCities = new HashSet<DiscountCity>();
        }

        [Key]
        [StringLength(10)]
        public string discount_code_codename { get; set; }

        public bool discount_code_ispercent { get; set; }

        public decimal discount_code_amount { get; set; }

        [Column(TypeName = "money")]
        public decimal discount_code_max_amount { get; set; }

        public DateTime discount_code_expdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discount> Discounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountCity> DiscountCities { get; set; }
    }
}
