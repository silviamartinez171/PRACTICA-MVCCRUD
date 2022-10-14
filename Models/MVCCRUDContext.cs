using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVCCRUD.Models
{
    public partial class MVCCRUDContext : DbContext
    {
        public MVCCRUDContext()
        {
        }

        public MVCCRUDContext(DbContextOptions<MVCCRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notaest> Notaests { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("server=DESKTOP-B6G5UO3; Database=MVCCRUD; integrated security =true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notaest>(entity =>
            {
                entity.ToTable("NOTAEST");

                entity.Property(e => e.Apellidos).HasMaxLength(30);

                entity.Property(e => e.Carnet).HasMaxLength(12);

                entity.Property(e => e.EXCI).HasColumnName("EXCI");

                entity.Property(e => e.IIC).HasColumnName("IIC");

                entity.Property(e => e.IIPN).HasColumnName("IIPN");

                entity.Property(e => e.IPN).HasColumnName("IPN");

                entity.Property(e => e.NF).HasColumnName("NF");

                entity.Property(e => e.NFCI).HasColumnName("NFCI");

                entity.Property(e => e.Nombres).HasMaxLength(30);

                entity.Property(e => e.PROYEC).HasColumnName("PROYEC");

                entity.Property(e => e.SIST).HasColumnName("SIST");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
