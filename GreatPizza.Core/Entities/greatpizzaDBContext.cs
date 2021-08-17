using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GreatPizza.Core.Entities
{
    public partial class greatpizzaDBContext : DbContext
    {
        public greatpizzaDBContext()
        {
        }

        public greatpizzaDBContext(DbContextOptions<greatpizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Pizzatoppings> Pizzatoppings { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=192.168.0.6;Database=greatpizzaDB;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.HasKey(e => e.Pizzaid)
                    .HasName("pizzas_pkey");

                entity.ToTable("pizzas");

                entity.HasComment("pizzas");

                entity.Property(e => e.Pizzaid)
                    .HasColumnName("pizzaid")
                    .HasDefaultValueSql("nextval('pizza_pizzaid_seq'::regclass)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Pizzatoppings>(entity =>
            {
                entity.HasKey(e => new { e.Pizzaid, e.Toppingid })
                    .HasName("pizzatoppings_pkey");

                entity.ToTable("pizzatoppings");

                entity.Property(e => e.Pizzaid).HasColumnName("pizzaid");

                entity.Property(e => e.Toppingid).HasColumnName("toppingid");
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.HasKey(e => e.Toppingid)
                    .HasName("toppings_pkey");

                entity.ToTable("toppings");

                entity.Property(e => e.Toppingid)
                    .HasColumnName("toppingid")
                    .HasDefaultValueSql("nextval('topping_toppingid_seq'::regclass)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(300);
            });

            modelBuilder.HasSequence("pizza_pizzaid_seq");

            modelBuilder.HasSequence("topping_toppingid_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
