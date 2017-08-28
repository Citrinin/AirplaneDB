namespace DAL_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Cargoes> Cargoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>()
                .Property(e => e.ModelName)
                .IsUnicode(false);

            modelBuilder.Entity<Airplane>()
                .HasMany(e => e.Cargoes)
                .WithRequired(e => e.Airplane)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cargoes>()
                .Property(e => e.CargoType)
                .IsUnicode(false);

            modelBuilder.Entity<Cargoes>()
                .Property(e => e.Destination)
                .IsUnicode(false);
        }
    }
}
