namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Customer()
        {
            tbl_Ticket = new HashSet<tbl_Ticket>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Customer_ID { get; set; }

        [StringLength(50)]
        public string fld_name { get; set; }

        [StringLength(50)]
        public string fld_email { get; set; }

        [StringLength(50)]
        public string fld_address { get; set; }

        [StringLength(50)]
        public string fld_phone_no { get; set; }

        [StringLength(30)]
        public string fld_password { get; set; }

        public int fld_Country { get; set; }

        public virtual tbl_Country_List tbl_Country_List { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Ticket> tbl_Ticket { get; set; }
    }
}
