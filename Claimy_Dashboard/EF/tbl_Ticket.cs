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
            tbl_Image = new HashSet<tbl_Image>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Ticket_ID { get; set; }

        [StringLength(100)]
        public string fld_Law_Violation { get; set; }

        [StringLength(30)]
        public string fld_tax_number { get; set; }

        public DateTime? fld_date_time { get; set; }

        [StringLength(20)]
        public string fld_car_reg_no { get; set; }

        public int? fld_parkingspace_id { get; set; }

        public int? fld_traffic_warden_no { get; set; }

        [StringLength(40)]
        public string fld_amount { get; set; }

        [StringLength(50)]
        public string fld_payment_info { get; set; }

        [StringLength(50)]
        public string fld_car_brand { get; set; }

        [StringLength(10)]
        public string fld_CVRNumber { get; set; }

        public int? fld_Customer_ID { get; set; }

        public virtual tbl_Customer tbl_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Image> tbl_Image { get; set; }

        public virtual tbl_Parking_Company tbl_Parking_Company { get; set; }
    }
}
