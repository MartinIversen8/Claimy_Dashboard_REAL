namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Ticket()
        {
            tbl_image = new HashSet<tbl_image>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_ID { get; set; }

        [StringLength(8000)]
        public string fld_law_violation { get; set; }

        [StringLength(50)]
        public string fld_tax_number { get; set; }

        public DateTime? fld_Data_time { get; set; }

        [StringLength(20)]
        public string fld_car_reg_no { get; set; }

        [StringLength(20)]
        public string fld_parkingspace_ID { get; set; }

        [StringLength(20)]
        public string fld_traffic_warden_no { get; set; }

        public decimal fld_amount { get; set; }

        [StringLength(30)]
        public string fld_payment_info { get; set; }

        [StringLength(30)]
        public string fld_car_brand { get; set; }

        [StringLength(20)]
        public string fld_CVRNR { get; set; }

        public int? fld_customer_ID { get; set; }

        public virtual tbl_Customer tbl_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_image> tbl_image { get; set; }

        public virtual tbl_parking_company tbl_parking_company { get; set; }
    }
}
