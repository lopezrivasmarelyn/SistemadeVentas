using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class DBContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; } 
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Puntos> Puntos { get; set; } 

        // Agrega aquí todas tus entidades

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SistemaVentasDB;Trusted_Connection=True;");
        }
    }
}
