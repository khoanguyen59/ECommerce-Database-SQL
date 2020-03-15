namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bill_id { get; set; }

        [Required]
        [StringLength(50)]
        public string bill_customer_mail { get; set; }

        public int bill_order_id { get; set; }

        [Required]
        [StringLength(50)]
        public string bill_address { get; set; }

        public DateTime bill_date { get; set; }

        [Required]
        [StringLength(10)]
        public string bill_payment_method { get; set; }

        [StringLength(16)]
        public string bill_credit_card_id { get; set; }

        [StringLength(10)]
        public string bill_ewallet_name { get; set; }

        public virtual CreditCard CreditCard { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual EWallet EWallet { get; set; }

        public virtual Order Order { get; set; }
    }
}
