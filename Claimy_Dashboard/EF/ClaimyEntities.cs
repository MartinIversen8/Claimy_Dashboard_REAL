namespace Claimy_Dashboard.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClaimyEntities : DbContext
    {
        public ClaimyEntities()
            : base("name=ClaimyEntities")
        {
        }

        public virtual DbSet<tbl_case> tbl_case { get; set; }
        public virtual DbSet<tbl_Claimy_Emp> tbl_Claimy_Emp { get; set; }
        public virtual DbSet<tbl_Country_List> tbl_Country_List { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_image> tbl_image { get; set; }
        public virtual DbSet<tbl_parking_company> tbl_parking_company { get; set; }
        public virtual DbSet<tbl_Ticket> tbl_Ticket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_case>()
                .Property(e => e.fld_p_fine_reason)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_case>()
                .Property(e => e.fld_precedent)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_case>()
                .Property(e => e.fld_status)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Claimy_Emp>()
                .Property(e => e.fld_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Claimy_Emp>()
                .Property(e => e.fld_email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Claimy_Emp>()
                .Property(e => e.fld_address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Claimy_Emp>()
                .Property(e => e.fld_password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Claimy_Emp>()
                .HasMany(e => e.tbl_case)
                .WithRequired(e => e.tbl_Claimy_Emp)
                .HasForeignKey(e => e.fld_Emp_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Country_List>()
                .Property(e => e.fld_country)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Country_List>()
                .Property(e => e.fld_zipcode)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Country_List>()
                .Property(e => e.fld_city)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Country_List>()
                .HasMany(e => e.tbl_Claimy_Emp)
                .WithRequired(e => e.tbl_Country_List)
                .HasForeignKey(e => e.fld_country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Country_List>()
                .HasMany(e => e.tbl_Customer)
                .WithRequired(e => e.tbl_Country_List)
                .HasForeignKey(e => e.fld_Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Country_List>()
                .HasMany(e => e.tbl_parking_company)
                .WithRequired(e => e.tbl_Country_List)
                .HasForeignKey(e => e.fld_country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_phone_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_image>()
                .Property(e => e.fld_description)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_parking_company>()
                .Property(e => e.fld_CVRNR)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_parking_company>()
                .Property(e => e.fld_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_parking_company>()
                .Property(e => e.fld_address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_parking_company>()
                .Property(e => e.fld_email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_parking_company>()
                .Property(e => e.fld_phone_nr)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_parking_company>()
                .Property(e => e.fld_contact_person)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_law_violation)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_tax_number)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_car_reg_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_parkingspace_ID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_traffic_warden_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_payment_info)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_car_brand)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_CVRNR)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .HasMany(e => e.tbl_image)
                .WithOptional(e => e.tbl_Ticket)
                .HasForeignKey(e => e.fld_ticket_ID);
        }
    }
}
