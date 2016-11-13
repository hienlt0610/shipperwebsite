namespace ShipperWebsite.Models.ShipperAdmin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShipperAdminDbContext : DbContext
    {
        public ShipperAdminDbContext()
            : base("name=ShipperAdminDbContext")
        {
        }

        public virtual DbSet<UserAdmin> UserAdmin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.Password_)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
