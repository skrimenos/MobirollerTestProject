using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MobirollerTestProject.DataAccess.Models;

#nullable disable

namespace MobirollerTestProject.DataAccess.Context
{
    public partial class MobirollerContext : DbContext
    {
        public MobirollerContext()
        {
        }

        public MobirollerContext(DbContextOptions<MobirollerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Italian> Italians { get; set; }
        public virtual DbSet<Turkish> Turkishes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Italian>(entity =>
            {
                entity.ToTable("Italian");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DcCategoria).HasColumnName("dc_Categoria");

                entity.Property(e => e.DcEvento).HasColumnName("dc_Evento");

                entity.Property(e => e.DcOrario).HasColumnName("dc_Orario");
            });

            modelBuilder.Entity<Turkish>(entity =>
            {
                entity.ToTable("Turkish");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DcKategori).HasColumnName("dc_Kategori");

                entity.Property(e => e.DcOlay).HasColumnName("dc_Olay");

                entity.Property(e => e.DcZaman).HasColumnName("dc_Zaman");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
