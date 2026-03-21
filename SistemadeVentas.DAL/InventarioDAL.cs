using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class InventarioDAL
    {
        public static async Task<int> CrearAsync(Inventario pInventario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pInventario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Inventario pInventario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var inventario = await dbContexto.Inventario
                    .FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);

                inventario.IdProducto = pInventario.IdProducto;
                inventario.StockAnual = pInventario.StockAnual;
                inventario.StockMinimo = pInventario.StockMinimo;
                inventario.UltimaActualizacion = DateTime.Now;

                dbContexto.Update(inventario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Inventario pInventario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var inventario = await dbContexto.Inventario
                    .FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);

                dbContexto.Inventario.Remove(inventario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Inventario> ObtenerPorIdAsync(Inventario pInventario)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Inventario
                    .Include(i => i.Producto) // para traer relación
                    .FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);
            }
        }

        public static async Task<List<Inventario>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Inventario
                    .Include(i => i.Producto)
                    .ToListAsync();
            }
        }

        public static async Task<List<Inventario>> BuscarAsync(Inventario pInventario)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Inventario
                    .Include(i => i.Producto)
                    .AsQueryable();

                if (pInventario.IdInventario > 0)
                    query = query.Where(s => s.IdInventario == pInventario.IdInventario);

                if (pInventario.IdProducto > 0)
                    query = query.Where(s => s.IdProducto == pInventario.IdProducto);

                return await query.ToListAsync();
            }
        }
    }
}