using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiRest.Entities;

namespace ApiRest.Context
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camarero> Camareros { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Cocinero> Cocineros { get; set; } = null!;
        public virtual DbSet<Comanda> Comanda { get; set; } = null!;
        public virtual DbSet<Gerente> Gerentes { get; set; } = null!;
        public virtual DbSet<Mesa> Mesas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=MariaDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.34-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Camarero>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Camarero)
                    .HasForeignKey<Camarero>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_camareroUser");
            });

            modelBuilder.Entity<Cocinero>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Cocinero)
                    .HasForeignKey<Cocinero>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cocineroUser");
            });

            modelBuilder.Entity<Comanda>(entity =>
            {
                entity.HasOne(d => d.IdCamareroNavigation)
                    .WithMany(p => p.Comanda)
                    .HasForeignKey(d => d.IdCamarero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_camarerocomanda");

                entity.HasOne(d => d.IdCocineroNavigation)
                    .WithMany(p => p.Comanda)
                    .HasForeignKey(d => d.IdCocinero)
                    .HasConstraintName("fk_cocinerocomanda");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.Comanda)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pedidocomanda");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Comanda)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_productocomanda");
            });

            modelBuilder.Entity<Gerente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Gerente)
                    .HasForeignKey<Gerente>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_gerenteUser");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasMany(d => d.IdReservas)
                    .WithMany(p => p.IdMesas)
                    .UsingEntity<Dictionary<string, object>>(
                        "Mesareserva",
                        l => l.HasOne<Reserva>().WithMany().HasForeignKey("IdReserva").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_reservamesa"),
                        r => r.HasOne<Mesa>().WithMany().HasForeignKey("IdMesa").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_mesareserva"),
                        j =>
                        {
                            j.HasKey("IdMesa", "IdReserva").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("mesareserva");

                            j.HasIndex(new[] { "IdReserva" }, "fk_reservamesa");

                            j.IndexerProperty<int>("IdMesa").HasColumnType("int(50)").HasColumnName("id_mesa");

                            j.IndexerProperty<int>("IdReserva").HasColumnType("int(50)").HasColumnName("id_reserva");
                        });
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasOne(d => d.IdMesaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdMesa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idmesa");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_catProd");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
