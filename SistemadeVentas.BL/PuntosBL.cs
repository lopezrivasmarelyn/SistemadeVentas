//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.DAL;

namespace SistemadeVentas.BL
{
    public class PuntosBL
    {
        public async Task<int> CrearAsync(Puntos pPuntos)
        {
            return await PuntosDAL.CrearAsync(pPuntos);
        }

        public async Task<int> ModificarAsync(Puntos pPuntos)
        {
            return await PuntosDAL.ModificarAsync(pPuntos);
        }

        public async Task<int> EliminarAsync(Puntos pPuntos)
        {
            return await PuntosDAL.EliminarAsync(pPuntos);
        }

        public async Task<List<Puntos>> BuscarAsync(Puntos pPuntos)
        {
            return await PuntosDAL.BuscarAsync(pPuntos);
        }

        public async Task<List<Puntos>> ObtenerTodosAsync()
        {
            return await PuntosDAL.ObtenerTodosAsync();
        }

        public static Task<string> GenerarCodigoDescuentoAsync(Puntos pPuntos)
        {
            // Genera un código aleatorio seguro y rellena algunos campos del objeto.
            var bytes = new byte[9];
            System.Security.Cryptography.RandomNumberGenerator.Fill(bytes);
            string codigo = Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "");

            pPuntos.CodigoDescuento = codigo;
            pPuntos.FechaGenerarCodigo = DateTime.UtcNow;
            pPuntos.FechaExpiracionCodigo = DateTime.UtcNow.AddDays(30);
            pPuntos.EstadoCodigo = "Activo";

            // TODO: Persistir cambios en la base de datos 
            return Task.FromResult(codigo);
        }

        public static Task<bool> CanjearPuntosAsync(Puntos pPuntos)
        {
            // Lógica de ejemplo: comprobar puntos y marcar como canjeado.
            // TODO: implementar verificación/actualización en la base de datos.
            bool exito = false;

            if (pPuntos != null && pPuntos.PuntosAcumulados >= 0)
            {
                // lógica real aquí...
                exito = true;
            }

            return Task.FromResult(exito);
        }
}   }
