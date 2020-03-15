namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class Discount
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string discount_customer_mail { get; set; }

        public int? discount_order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string discount_discount_codename { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DiscountCode DiscountCode { get; set; }

        public virtual Order Order { get; set; }
    }
}
