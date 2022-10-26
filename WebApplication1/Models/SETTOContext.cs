using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class SETTOContext : DbContext
    {
        public SETTOContext()
        {
        }

        public SETTOContext(DbContextOptions<SETTOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Correspondencium> Correspondencia { get; set; } = null!;
        public virtual DbSet<Guardium> Guardia { get; set; } = null!;
        public virtual DbSet<Inquilino> Inquilinos { get; set; } = null!;
        public virtual DbSet<ModificacionAdmin> ModificacionAdmins { get; set; } = null!;
        public virtual DbSet<Modificacione> Modificaciones { get; set; } = null!;
        public virtual DbSet<Perfile> Perfiles { get; set; } = null!;
        public virtual DbSet<Solicitude> Solicitudes { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public virtual DbSet<Visitante> Visitantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-D4K75HQ\\SQLEXPRESS; Database=SETTO; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DocumentoAd).HasColumnName("documentoAd");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Correspondencium>(entity =>
            {
                entity.HasKey(e => e.IdCorrespondencia)
                    .HasName("PK__Correspo__BC78E9D4EE9B3B3E");

                entity.Property(e => e.IdCorrespondencia)
                    .ValueGeneratedNever()
                    .HasColumnName("idCorrespondencia");

                entity.Property(e => e.DocumentoInqui).HasColumnName("documentoInqui");

                entity.Property(e => e.TipoCorrespondencia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipoCorrespondencia");


            });

            modelBuilder.Entity<Guardium>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Documento).HasColumnName("documento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Inquilino>(entity =>
            {
                entity.HasKey(e => e.DocumentoInqui)
                    .HasName("PK__Inquilin__0A7AF19D2BD43785");

                entity.Property(e => e.DocumentoInqui)
                    .ValueGeneratedNever()
                    .HasColumnName("documentoInqui");

                entity.Property(e => e.Apartamento).HasColumnName("apartamento");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Torre).HasColumnName("torre");

                entity.Property(e => e.Vehiculo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("vehiculo");
                    

            });

            modelBuilder.Entity<ModificacionAdmin>(entity =>
            {
                entity.ToTable("modificacion_admin");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Accion)
                    .HasMaxLength(10)
                    .HasColumnName("accion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Modificacione>(entity =>
            {
                entity.ToTable("modificaciones");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Accion)
                    .HasMaxLength(10)
                    .HasColumnName("accion")
                    .IsFixedLength();


            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.HasKey(e => e.DocumentoPer)
                    .HasName("PK__Perfiles__46ACCEB8EB19969C");

                entity.Property(e => e.DocumentoPer)
                    .ValueGeneratedNever()
                    .HasColumnName("documentoPer");

                entity.Property(e => e.DocumentoInqui).HasColumnName("documentoInqui");

                entity.Property(e => e.Edad)
                    .HasMaxLength(3)
                    .HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud)
                    .HasName("PK__solicitu__D801DDB85EE21C53");

                entity.ToTable("solicitudes");

                entity.Property(e => e.IdSolicitud)
                    .ValueGeneratedNever()
                    .HasColumnName("idSolicitud");

                entity.Property(e => e.Documentoinqui).HasColumnName("documentoinqui");

                entity.Property(e => e.Estado)
                    .HasMaxLength(11)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaSoli)
                    .HasColumnType("date")
                    .HasColumnName("fechaSoli");

                entity.Property(e => e.HoraSoli).HasColumnName("horaSoli");

                entity.Property(e => e.TipoSoli)
                    .HasMaxLength(100)
                    .HasColumnName("tipoSoli");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.Placa)
                    .HasName("PK__Vehiculo__0C05742499EFF4B8");

                entity.ToTable("Vehiculo");

                entity.Property(e => e.Placa).HasColumnName("placa");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Documentoinqui).HasColumnName("documentoinqui");

                entity.Property(e => e.Modelo).HasColumnName("modelo");

                entity.Property(e => e.TipoVehiculo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("tipoVehiculo");

            });

            modelBuilder.Entity<Visitante>(entity =>
            {
                entity.HasKey(e => e.DocumentoVisi)
                    .HasName("PK__Visitant__BFC97557589CB610");

                entity.ToTable("Visitante");

                entity.Property(e => e.DocumentoVisi)
                    .ValueGeneratedNever()
                    .HasColumnName("documentoVisi");

                entity.Property(e => e.DetallesVisi)
                    .HasColumnType("text")
                    .HasColumnName("detallesVisi");

                entity.Property(e => e.Documentoinqui).HasColumnName("documentoinqui");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.NombreVisi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nombreVisi");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
