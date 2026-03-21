using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class DetalleVentaDAL
    {
        public static async Task<int> CrearAsync(DetalleVenta pDetalle)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                // calcular subtotal automáticamente
                pDetalle.SubTotal = pDetalle.Cantidad * pDetalle.PrecioUnitario;

                dbContexto.Add(pDetalle);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(DetalleVenta pDetalle)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var detalle = await dbContexto.DetalleVenta
                    .FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalle.IdDetalleVenta);

                detalle.IdVenta = pDetalle.IdVenta;
                detalle.IdProducto = pDetalle.IdProducto;
                detalle.Cantidad = pDetalle.Cantidad;
                detalle.PrecioUnitario = pDetalle.PrecioUnitario;

                // recalcular subtotal
                detalle.SubTotal = detalle.Cantidad * detalle.PrecioUnitario;

                dbContexto.Update(detalle);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(DetalleVenta pDetalle)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var detalle = await dbContexto.DetalleVenta
                    .FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalle.IdDetalleVenta);

                dbContexto.DetalleVenta.Remove(detalle);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<DetalleVenta> ObtenerPorIdAsync(DetalleVenta pDetalle)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.DetalleVenta
                    .Include(d => d.Producto)
                    .Include(d => d.Venta)
                    .FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalle.IdDetalleVenta);
            }
        }

        public static async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.DetalleVenta
                    .Include(d => d.Producto)
                    .Include(d => d.Venta)
                    .ToListAsync();
            }
        }

        public static async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalle)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.DetalleVenta
                    .Include(d => d.Producto)
                    .Include(d => d.Venta)
                    .AsQueryable();

                if (pDetalle.IdDetalleVenta > 0)
                    query = query.Where(s => s.IdDetalleVenta == pDetalle.IdDetalleVenta);

                if (pDetalle.IdVenta > 0)
                    query = query.Where(s => s.IdVenta == pDetalle.IdVenta);

                if (pDetalle.IdProducto > 0)
                    query = query.Where(s => s.IdProducto == pDetalle.IdProducto);

                return await query.ToListAsync();
            }
        }
    }
}