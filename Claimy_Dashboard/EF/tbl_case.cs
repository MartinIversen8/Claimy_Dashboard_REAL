namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_case
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_case_no { get; set; }

        [Required]
        [StringLength(200)]
        public string fld_p_fine_reason { get; set; }

        [StringLength(50)]
        public string fld_precedent { get; set; }

        [Required]
        [StringLength(50)]
        public string fld_status { get; set; }

        public int fld_Emp_ID { get; set; }

        public int fld_Customer_ID { get; set; }

        public virtual tbl_Claimy_Emp tbl_Claimy_Emp { get; set; }
    }
}
