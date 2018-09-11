namespace ModelsData.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SEDbContext : DbContext
    {
        public SEDbContext()
            : base("name=SEDbContext")
        {
        }

        public virtual DbSet<tblUser> tblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.PWD)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<tblUser>()
                .Property(e => e.UserType)
                .IsUnicode(false);
        }
    }
}
