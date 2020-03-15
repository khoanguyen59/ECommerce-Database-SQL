namespace ECommerce.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipper")]
    public partial class Shipper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipper()
        {
            Ships = new HashSet<Ship>();
        }

        [Key]
        [StringLength(9)]
        public string shipper_pid { get; set; }

        [Required]
        [StringLength(20)]
        public string shipper_fname { get; set; }

        [Required]
        [StringLength(20)]
        public string shipper_lname { get; set; }

        [Required]
        [StringLength(10)]
        public string shipper_phone { get; set; }

        [StringLength(50)]
        public string shipper_address { get; set; }

        [Required]
        [StringLength(12)]
        public string shipper_license { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ship> Ships { get; set; }
    }
}
