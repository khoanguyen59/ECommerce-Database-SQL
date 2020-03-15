namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int review_no { get; set; }

        public int review_rating { get; set; }

        [StringLength(1000)]
        public string review_comment { get; set; }

        public byte[] review_picture { get; set; }

        [Required]
        [StringLength(50)]
        public string review_customer_mail { get; set; }

        public int review_product_id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}
