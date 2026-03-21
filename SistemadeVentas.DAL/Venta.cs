using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class VentaDAL
    {
        public static async Task<int> CrearAsync(Venta pVenta)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                pVenta.FechaVenta = DateTime.Now;

                dbContexto.Add(pVenta);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Venta pVenta)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var venta = await dbContexto.Venta
                    .FirstOrDefaultAsync(s => s.IdVenta == pVenta.IdVenta);

                venta.IdUsuario = pVenta.IdUsuario;
                venta.Total = pVenta.Total;
                venta.TipoPago = pVenta.TipoPago;
                venta.Estado = pVenta.Estado;

                dbContexto.Update(venta);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Venta pVenta)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var venta = await dbContexto.Venta
                    .FirstOrDefaultAsync(s => s.IdVenta == pVenta.IdVenta);

                dbContexto.Venta.Remove(venta);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Venta> ObtenerPorIdAsync(Venta pVenta)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Venta
                    .Include(v => v.Usuario) // 👈 relación
                    .FirstOrDefaultAsync(s => s.IdVenta == pVenta.IdVenta);
            }
        }

        public static async Task<List<Venta>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Venta
                    .Include(v => v.Usuario)
                    .ToListAsync();
            }
        }

        public static async Task<List<Venta>> BuscarAsync(Venta pVenta)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Venta
                    .Include(v => v.Usuario)
                    .AsQueryable();

                if (pVenta.IdVenta > 0)
                    query = query.Where(s => s.IdVenta == pVenta.IdVenta);

                if (pVenta.IdUsuario > 0)
                    query = query.Where(s => s.IdUsuario == pVenta.IdUsuario);

                if (!string.IsNullOrWhiteSpace(pVenta.TipoPago))
                    query = query.Where(s => s.TipoPago == pVenta.TipoPago);

                if (!string.IsNullOrWhiteSpace(pVenta.Estado))
                    query = query.Where(s => s.Estado == pVenta.Estado);

                return await query.ToListAsync();
            }
        }
    }
}
