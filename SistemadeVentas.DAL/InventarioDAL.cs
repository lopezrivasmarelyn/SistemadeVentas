using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class InventarioDAL
    {
        // ✅ Solo se usa internamente desde ProductoDAL, no desde el controlador
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

                if (inventario == null) return 0;

                inventario.StockAnual = pInventario.StockAnual;
                inventario.StockMinimo = pInventario.StockMinimo;
                inventario.UltimaActualizacion = DateTime.Now;
                // ✅ IdProducto NO se modifica, el producto ya está asignado

                dbContexto.Update(inventario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        // ✅ Solo se llama desde EliminarAsync de Producto, no desde el controlador
        public static async Task<int> EliminarAsync(Inventario pInventario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var inventario = await dbContexto.Inventario
                    .FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);

                if (inventario == null) return 0;

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
                    .Include(i => i.Producto)
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

        public static async Task ActualizarStockAsync(Inventario pInventario)
        {
            using (var dbContexto = new DBContexto())
            {
                var inventario = await dbContexto.Inventario
                    .FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);

                if (inventario == null) return;

                inventario.StockAnual = pInventario.StockAnual;
                inventario.UltimaActualizacion = DateTime.Now;

                dbContexto.Update(inventario);
                await dbContexto.SaveChangesAsync();
            }
        }

        public static async Task<bool> VerificarStockMinimoAsync(Inventario pInventario)
        {
            using (var dbContexto = new DBContexto())
            {
                var inventario = await dbContexto.Inventario
                    .FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);

                if (inventario == null) return false;

                return inventario.StockAnual < inventario.StockMinimo;
            }
        }
    }
}