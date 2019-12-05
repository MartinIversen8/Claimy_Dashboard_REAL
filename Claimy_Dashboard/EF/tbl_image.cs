namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Image_ID { get; set; }

        public byte[] fld_image { get; set; }

        public int? fld_Ticket_ID { get; set; }

        public virtual tbl_Ticket tbl_Ticket { get; set; }
    }
}
