using SistemadeVentas.EN;
using SistemadeVentas.DAL;

namespace SistemadeVentas.BL
{
    public class ProductoBL
    {
        public async Task<int> CrearAsync(Producto pProducto)
        {
            return await ProductoDAL.CrearAsync(pProducto);
            // ✅ Esto ahora también crea el inventario automáticamente (lo maneja el DAL)
        }

        public async Task<int> ModificarAsync(Producto pProducto)
        {
            return await ProductoDAL.ModificarAsync(pProducto);
        }

        public async Task<int> EliminarAsync(Producto pProducto)
        {
            return await ProductoDAL.EliminarAsync(pProducto);
            // ✅ Esto ahora también elimina el inventario primero (lo maneja el DAL)
        }

        public async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            return await ProductoDAL.BuscarAsync(pProducto);
        }

        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await ProductoDAL.ObtenerTodosAsync();
        }

        public async Task ActualizarPrecioAsync(Producto pProducto)
        {
            await ProductoDAL.ModificarAsync(pProducto);
        }
    }
}