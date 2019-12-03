namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Country_List
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Country_List()
        {
            tbl_Claimy_Emp = new HashSet<tbl_Claimy_Emp>();
            tbl_Customer = new HashSet<tbl_Customer>();
            tbl_parking_company = new HashSet<tbl_parking_company>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_number { get; set; }

        [Required]
        [StringLength(25)]
        public string fld_country { get; set; }

        [Required]
        [StringLength(10)]
        public string fld_zipcode { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_city { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Claimy_Emp> tbl_Claimy_Emp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Customer> tbl_Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_parking_company> tbl_parking_company { get; set; }
    }
}
