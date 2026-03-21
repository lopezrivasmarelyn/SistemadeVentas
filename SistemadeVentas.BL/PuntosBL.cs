//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.BL;

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

        public async Task<Puntos> BuscarAsync(Puntos pPuntos)
        {
            return await PuntosDAL.BuscarAsync(pPuntos);
        }

        public async Task<List<Puntos>> ObtenerTodosAsync()
        {
            return await PuntosDAL.ObtenerTodosAsync();
        }

        public async Task<string> GenerarCodigoDescuentoAsync(Puntos pPuntos)
        {
            return await PuntosDAL.GenerarCodigoDescuentoAsync(pPuntos);
        }

        public async Task<bool> CanjearPuntosAsync(Puntos pPuntos)
        {
            return await PuntosDAL.CanjearPuntosAsync(pPuntos);
        }
    }
