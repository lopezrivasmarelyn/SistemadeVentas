using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pRol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol
                    .FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);

                rol.Nombre = pRol.Nombre;

                dbContexto.Update(rol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol
                    .FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);

                dbContexto.Rol.Remove(rol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Rol> ObtenerPorIdAsync(Rol pRol)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Rol
                    .FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
            }
        }

        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Rol.ToListAsync();
            }
        }

        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Rol.AsQueryable();

                if (pRol.IdRol > 0)
                    query = query.Where(s => s.IdRol == pRol.IdRol);

                if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                    query = query.Where(s => s.Nombre.Contains(pRol.Nombre));

                return await query.ToListAsync();
            }
        }
    }
}