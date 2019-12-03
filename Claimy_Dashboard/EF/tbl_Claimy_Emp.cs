namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Claimy_Emp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Claimy_Emp()
        {
            tbl_case = new HashSet<tbl_case>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Employee_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_name { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_email { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_address { get; set; }

        public int fld_country { get; set; }

        [Required]
        [StringLength(30)]
        public string fld_password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_case> tbl_case { get; set; }

        public virtual tbl_Country_List tbl_Country_List { get; set; }
    }
}
