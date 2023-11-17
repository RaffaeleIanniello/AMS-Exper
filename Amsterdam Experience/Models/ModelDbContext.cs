using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Amsterdam_Experience.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Esperienze> Esperienze { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Esperienze>()
                .Property(e => e.prezzoEsperienza)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Esperienze>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Esperienze)
                .HasForeignKey(e => e.fkEsperienze)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Utenti)
                .HasForeignKey(e => e.fkUtenti)
                .WillCascadeOnDelete(false);
        }
    }
}
