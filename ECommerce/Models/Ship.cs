namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ship")]
    public partial class Ship
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ship_order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string ship_shipper_pid { get; set; }

        public DateTime? ship_date { get; set; }

        public virtual Order Order { get; set; }

        public virtual Shipper Shipper { get; set; }
    }
}
