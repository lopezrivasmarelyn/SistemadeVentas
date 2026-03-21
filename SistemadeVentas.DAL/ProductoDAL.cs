using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pProducto);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var producto = await dbContexto.Producto
                    .FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);

                producto.IdCategoria = pProducto.IdCategoria;
                producto.Nombre = pProducto.Nombre;
                producto.Descripcion = pProducto.Descripcion;
                producto.Precio = pProducto.Precio;
                producto.Estado = pProducto.Estado;

                dbContexto.Update(producto);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var producto = await dbContexto.Producto
                    .FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);

                dbContexto.Producto.Remove(producto);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Producto
                    .Include(p => p.Categoria) // 👈 relación
                    .FirstOrDefaultAsync(s => s.IdProducto == pProducto.IdProducto);
            }
        }

        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Producto
                    .Include(p => p.Categoria)
                    .ToListAsync();
            }
        }

        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Producto
                    .Include(p => p.Categoria)
                    .AsQueryable();

                if (pProducto.IdProducto > 0)
                    query = query.Where(s => s.IdProducto == pProducto.IdProducto);

                if (pProducto.IdCategoria > 0)
                    query = query.Where(s => s.IdCategoria == pProducto.IdCategoria);

                if (!string.IsNullOrWhiteSpace(pProducto.Nombre))
                    query = query.Where(s => s.Nombre.Contains(pProducto.Nombre));

                if (!string.IsNullOrWhiteSpace(pProducto.Estado))
                    query = query.Where(s => s.Estado == pProducto.Estado);

                return await query.ToListAsync();
            }
        }
    }
}