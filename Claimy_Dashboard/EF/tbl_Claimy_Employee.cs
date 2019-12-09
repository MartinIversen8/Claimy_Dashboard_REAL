namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Claimy_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Claimy_Employee()
        {
            tbl_Case = new HashSet<tbl_Case>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Employee_ID { get; set; }

        [StringLength(50)]
        public string fld_Name { get; set; }

        [StringLength(50)]
        public string fld_Adress { get; set; }

        [StringLength(50)]
        public string fld_Email { get; set; }

        [StringLength(15)]
        public string fld_Phone_No { get; set; }

        [StringLength(25)]
        public string fld_Password { get; set; }

        public int? fld_Country_Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Case> tbl_Case { get; set; }

        public virtual tbl_Country_List tbl_Country_List { get; set; }

        public override string ToString()
        {
            // Since the PetName column could be empty, supply
            // the default name of **No Name**.

            return $"{this.fld_Employee_ID}, {this.fld_Name}, {this.fld_Adress}, {this.fld_Email}, {this.fld_Phone_No}, {this.fld_Password}, {this.fld_Country_Number}";
        }
}

 }
