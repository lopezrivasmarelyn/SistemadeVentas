using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class PuntosDAL
    {
        public static async Task<int> CrearAsync(Puntos pPuntos)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                pPuntos.FechaActualizacion = DateTime.Now;

                dbContexto.Add(pPuntos);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Puntos pPuntos)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var puntos = await dbContexto.Puntos
                    .FirstOrDefaultAsync(s => s.IdPuntos == pPuntos.IdPuntos);

                puntos.IdUsuario = pPuntos.IdUsuario;
                puntos.PuntosAcumulados = pPuntos.PuntosAcumulados;
                puntos.CodigoDescuento = pPuntos.CodigoDescuento;
                puntos.PorcentajeDescuento = pPuntos.PorcentajeDescuento;
                puntos.FechaGenerarCodigo = pPuntos.FechaGenerarCodigo;
                puntos.FechaExpiracionCodigo = pPuntos.FechaExpiracionCodigo;
                puntos.EstadoCodigo = pPuntos.EstadoCodigo;
                puntos.FechaActualizacion = DateTime.Now;

                dbContexto.Update(puntos);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Puntos pPuntos)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var puntos = await dbContexto.Puntos
                    .FirstOrDefaultAsync(s => s.IdPuntos == pPuntos.IdPuntos);

                dbContexto.Puntos.Remove(puntos);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Puntos> ObtenerPorIdAsync(Puntos pPuntos)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Puntos
                    .Include(p => p.Usuario) // 👈 relación
                    .FirstOrDefaultAsync(s => s.IdPuntos == pPuntos.IdPuntos);
            }
        }

        public static async Task<List<Puntos>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Puntos
                    .Include(p => p.Usuario)
                    .ToListAsync();
            }
        }

        public static async Task<List<Puntos>> BuscarAsync(Puntos pPuntos)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Puntos
                    .Include(p => p.Usuario)
                    .AsQueryable();

                if (pPuntos.IdPuntos > 0)
                    query = query.Where(s => s.IdPuntos == pPuntos.IdPuntos);

                if (pPuntos.IdUsuario > 0)
                    query = query.Where(s => s.IdUsuario == pPuntos.IdUsuario);

                if (!string.IsNullOrWhiteSpace(pPuntos.EstadoCodigo))
                    query = query.Where(s => s.EstadoCodigo == pPuntos.EstadoCodigo);

                return await query.ToListAsync();
            }
        }
    }
}