namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deleted_Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        [Required]
        [StringLength(20)]
        public string product_name { get; set; }

        public byte[] product_picture { get; set; }

        [StringLength(20)]
        public string product_brand { get; set; }

        public int? product_categoryid { get; set; }

        public int product_price { get; set; }

        public int product_quantity { get; set; }

        public DateTime? product_deleted_time { get; set; }
    }
}
