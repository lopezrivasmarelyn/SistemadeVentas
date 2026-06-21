//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.DAL;

namespace SistemadeVentas.BL
{
    public class VentaBL
    {
        public async Task<int> CrearAsync(Venta pVenta)
        {
            return await VentaDAL.CrearAsync(pVenta);
        }

        public async Task<int> ModificarAsync(Venta pVenta)
        {
            return await VentaDAL.ModificarAsync(pVenta);
        }

        public async Task<int> EliminarAsync(Venta pVenta)
        {
            return await VentaDAL.EliminarAsync(pVenta);
        }

        public async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            return await VentaDAL.BuscarAsync(pVenta);
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await VentaDAL.ObtenerTodosAsync();
        }

        public static Task<decimal> CalcularTotalAsync(Venta pVenta)
        {
            if (pVenta == null) throw new ArgumentNullException(nameof(pVenta));

            // Si el total ya está en la entidad, devolverlo.
            // Cambia la lógica aquí si necesitas calcularlo a partir de detalles en BD.
            return Task.FromResult(pVenta.Total);
        }
    }
}
