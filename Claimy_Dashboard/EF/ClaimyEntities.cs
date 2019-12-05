namespace Claimy_Dashboard.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClaimyEntities : DbContext
    {
        public ClaimyEntities()
            : base("name=ClaimyEntities2")
        {
        }

        public virtual DbSet<tbl_Case> tbl_Case { get; set; }
        public virtual DbSet<tbl_Claimy_Employee> tbl_Claimy_Employee { get; set; }
        public virtual DbSet<tbl_Country_List> tbl_Country_List { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_Image> tbl_Image { get; set; }
        public virtual DbSet<tbl_Parking_Company> tbl_Parking_Company { get; set; }
        public virtual DbSet<tbl_Ticket> tbl_Ticket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Case>()
                .Property(e => e.fld_ParkingFine_Reason)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Case>()
                .Property(e => e.fld_Precedens)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Case>()
                .Property(e => e.fld_Status)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Claimy_Employee>()
                .Property(e => e.fld_Name)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Claimy_Employee>()
                .Property(e => e.fld_Adress)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Claimy_Employee>()
                .Property(e => e.fld_Email)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Claimy_Employee>()
                .Property(e => e.fld_Phone_No)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Claimy_Employee>()
                .Property(e => e.fld_Password)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Claimy_Employee>()
                .HasMany(e => e.tbl_Case)
                .WithOptional(e => e.tbl_Claimy_Employee)
                .HasForeignKey(e => e.fld_EMP_ID);

            modelBuilder.Entity<tbl_Country_List>()
                .Property(e => e.fld_Country)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Country_List>()
                .Property(e => e.fld_ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Country_List>()
                .Property(e => e.fld_City)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Country_List>()
                .HasMany(e => e.tbl_Claimy_Employee)
                .WithOptional(e => e.tbl_Country_List)
                .HasForeignKey(e => e.fld_Country_Number);

            modelBuilder.Entity<tbl_Country_List>()
                .HasMany(e => e.tbl_Customer)
                .WithOptional(e => e.tbl_Country_List)
                .HasForeignKey(e => e.fld_Country_Number);

            modelBuilder.Entity<tbl_Country_List>()
                .HasMany(e => e.tbl_Parking_Company)
                .WithOptional(e => e.tbl_Country_List)
                .HasForeignKey(e => e.fld_Country_Number);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_Name)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_Adress)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_Email)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_Phone_No)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.fld_Password)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Parking_Company>()
                .Property(e => e.fld_CVRNR)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Parking_Company>()
                .Property(e => e.fld_Name)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Parking_Company>()
                .Property(e => e.fld_Adress)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Parking_Company>()
                .Property(e => e.fld_Email)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Parking_Company>()
                .Property(e => e.fld_Phone_No)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Parking_Company>()
                .Property(e => e.fld_Contact_Person)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Parking_Company>()
                .HasMany(e => e.tbl_Ticket)
                .WithOptional(e => e.tbl_Parking_Company)
                .HasForeignKey(e => e.fld_CVRNumber);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_Law_Violation)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_tax_number)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_car_reg_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_amount)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_payment_info)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_car_brand)
                .IsFixedLength();

            modelBuilder.Entity<tbl_Ticket>()
                .Property(e => e.fld_CVRNumber)
                .IsUnicode(false);
        }
    }
}
