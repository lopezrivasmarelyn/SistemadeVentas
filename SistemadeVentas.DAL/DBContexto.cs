using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class DBContexto : DbContext
    {
        //constructor
        public DBContexto(DbContextOptions<DBContexto> options)
            : base(options) { }

        // inyeccion en los DAL
        public DBContexto() { }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; } 
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Puntos> Puntos { get; set; } 

        // Agrega aquí todas tus entidades

       
    }
}
