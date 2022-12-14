using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace INVENNET.Models
{
    public partial class INVENETContext : DbContext
    {
        public INVENETContext()
        {
        }

        public INVENETContext(DbContextOptions<INVENETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("server=DESKTOP-3N43NEP\\SQLEXPRESS; database=INVENET; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallesPedido>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__DetallesP__IdPed__49C3F6B7");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.DetallesPedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__DetallesP__IdPro__48CFD27E");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Creado')");

                entity.Property(e => e.FechaAprobacion).HasColumnType("date");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaRecepcion).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCaducidad).HasColumnType("date");

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Marca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Productos__IdCat__44FF419A");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK__Productos__IdPro__440B1D61");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
