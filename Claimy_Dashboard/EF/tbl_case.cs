namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Case_NO { get; set; }

        [StringLength(50)]
        public string fld_ParkingFine_Reason { get; set; }

        [StringLength(50)]
        public string fld_Precedens { get; set; }

        [StringLength(25)]
        public string fld_Status { get; set; }

        public int? fld_EMP_ID { get; set; }

        public virtual tbl_Claimy_Employee tbl_Claimy_Employee { get; set; }

        
    }
}
