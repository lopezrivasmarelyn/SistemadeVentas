//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.DAL;


namespace SistemadeVentas.BL
{
    public class DetalleVentaBL
    {
        public async Task<int> CrearAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.CrearAsync(pDetalleVenta);
        }

        public async Task<int> ModificarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.ModificarAsync(pDetalleVenta);
        }

        public async Task<int> EliminarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.EliminarAsync(pDetalleVenta);
        }

        public async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.BuscarAsync(pDetalleVenta);
        }

        public async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            return await DetalleVentaDAL.ObtenerTodosAsync();
        }

        public Task<decimal> CalcularSubtotalAsync(DetalleVenta pDetalleVenta)
        {
            if (pDetalleVenta is null) throw new ArgumentNullException(nameof(pDetalleVenta));
            decimal subtotal = pDetalleVenta.Cantidad * pDetalleVenta.PrecioUnitario;
            return Task.FromResult(subtotal);
        }
    }
}
