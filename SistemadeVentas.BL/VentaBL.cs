//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.BL;

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

        public async Task<Venta> BuscarAsync(Venta pVenta)
        {
            return await VentaDAL.BuscarAsync(pVenta);
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await VentaDAL.ObtenerTodosAsync();
        }

        public async Task<decimal> CalcularTotalAsync(Venta pVenta)
        {
            return await VentaDAL.CalcularTotalAsync(pVenta);
        }
    }
