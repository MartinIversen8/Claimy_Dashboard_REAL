namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_parking_company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_parking_company()
        {
            tbl_Ticket = new HashSet<tbl_Ticket>();
        }

        [Key]
        [StringLength(20)]
        public string fld_CVRNR { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_name { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_address { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_email { get; set; }

        [Required]
        [StringLength(30)]
        public string fld_phone_nr { get; set; }

        [StringLength(50)]
        public string fld_contact_person { get; set; }

        public int fld_country { get; set; }

        public virtual tbl_Country_List tbl_Country_List { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Ticket> tbl_Ticket { get; set; }
    }
}
