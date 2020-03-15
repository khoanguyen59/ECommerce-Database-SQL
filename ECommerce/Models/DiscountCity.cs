namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountCity")]
    public partial class DiscountCity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string discount_city_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string discount_city_codename { get; set; }

        public virtual DiscountCode DiscountCode { get; set; }
    }
}
