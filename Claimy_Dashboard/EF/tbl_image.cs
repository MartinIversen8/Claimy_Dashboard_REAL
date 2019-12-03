namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] fld_image { get; set; }

        [StringLength(100)]
        public string fld_description { get; set; }

        public int? fld_ticket_ID { get; set; }

        public virtual tbl_Ticket tbl_Ticket { get; set; }
    }
}
