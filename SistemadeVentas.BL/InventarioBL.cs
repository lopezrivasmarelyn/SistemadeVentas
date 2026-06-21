using SistemadeVentas.EN;
using SistemadeVentas.DAL;

namespace SistemadeVentas.BL
{
    public class InventarioBL
    {
        // ✅ Se mantiene pero solo lo llama ProductoDAL internamente
        public async Task<int> CrearAsync(Inventario pInventario)
        {
            return await InventarioDAL.CrearAsync(pInventario);
        }

        public async Task<int> ModificarAsync(Inventario pInventario)
        {
            return await InventarioDAL.ModificarAsync(pInventario);
        }

        // ✅ Se mantiene pero solo lo llama ProductoDAL internamente
        public async Task<int> EliminarAsync(Inventario pInventario)
        {
            return await InventarioDAL.EliminarAsync(pInventario);
        }

        public async Task<List<Inventario>> BuscarAsync(Inventario pInventario)
        {
            return await InventarioDAL.BuscarAsync(pInventario);
        }

        public async Task<List<Inventario>> ObtenerTodosAsync()
        {
            return await InventarioDAL.ObtenerTodosAsync();
        }

        public static async Task ActualizarStockAsync(Inventario pInventario)
        {
            await InventarioDAL.ActualizarStockAsync(pInventario);
            // ✅ Antes llamaba a ModificarAsync, ahora llama al método correcto
        }

        public static async Task<bool> VerificarStockMinimoAsync(Inventario pInventario)
        {
            var inv = await InventarioDAL.ObtenerPorIdAsync(pInventario);
            if (inv == null) return false;
            return inv.StockAnual < inv.StockMinimo;
            // ✅ Antes usaba <= lo cual marcaba stock bajo cuando era exactamente igual al mínimo
        }
    }
}