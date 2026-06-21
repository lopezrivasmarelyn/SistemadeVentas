using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options)
            : base(options) { }

        public DBContexto() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SistemadeVentasBD;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany()
                .HasForeignKey(u => u.IdRol);

            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.IdCategoria);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Producto)
                .WithMany()
                .HasForeignKey(i => i.IdProducto);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Usuario)
                .WithMany()
                .HasForeignKey(v => v.IdUsuario);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Venta)
                .WithMany()
                .HasForeignKey(d => d.IdVenta);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.IdProducto);

            modelBuilder.Entity<Puntos>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.IdUsuario);
        }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Puntos> Puntos { get; set; }
    }
}