//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.BL;


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

        public async Task<DetalleVenta> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.BuscarAsync(pDetalleVenta);
        }

        public async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            return await DetalleVentaDAL.ObtenerTodosAsync();
        }

        public async Task<decimal> CalcularSubtotalAsync(DetalleVenta pDetalleVenta)
        {
            return await DetalleVentaDAL.CalcularSubtotalAsync(pDetalleVenta);
        }
    }
