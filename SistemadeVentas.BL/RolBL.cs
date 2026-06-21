//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.DAL;

namespace SistemadeVentas.BL
{
    public class RolBL
    {
        public async Task<int> CrearAsync(Rol pRol)
        {
            return await RolDAL.CrearAsync(pRol);
        }
        public async Task<int> ModificarAsync(Rol pRol)
        {
            return await RolDAL.ModificarAsync(pRol);
        }
        public async Task<int> EliminarAsync(Rol pRol)
        {
            return await RolDAL.EliminarAsync(pRol);
        }
        public async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            return await RolDAL.BuscarAsync(pRol);
        }
        public async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {
            return await RolDAL.ObtenerPorIdAsync(pRol);
        }
        public async Task<List<Rol>> ObtenerTodosAsync()
        {
            return await RolDAL.ObtenerTodosAsync();
        }
    }
}