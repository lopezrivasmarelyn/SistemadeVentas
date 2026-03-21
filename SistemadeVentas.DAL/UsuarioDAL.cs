using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class UsuarioDAL
    {
        public static async Task<int> CrearAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                pUsuario.FechaRegistro = DateTime.Now;

                dbContexto.Add(pUsuario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var usuario = await dbContexto.Usuario
                    .FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);

                usuario.IdRol = pUsuario.IdRol;
                usuario.Nombre = pUsuario.Nombre;
                usuario.Apellido = pUsuario.Apellido;
                usuario.Telefono = pUsuario.Telefono;
                usuario.Clave = pUsuario.Clave;
                usuario.Estado = pUsuario.Estado;

                dbContexto.Update(usuario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Usuario pUsuario)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var usuario = await dbContexto.Usuario
                    .FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);

                dbContexto.Usuario.Remove(usuario);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Usuario
                    .Include(u => u.Rol) // 👈 relación
                    .FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
            }
        }

        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Usuario
                    .Include(u => u.Rol)
                    .ToListAsync();
            }
        }

        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Usuario
                    .Include(u => u.Rol)
                    .AsQueryable();

                if (pUsuario.IdUsuario > 0)
                    query = query.Where(s => s.IdUsuario == pUsuario.IdUsuario);

                if (pUsuario.IdRol > 0)
                    query = query.Where(s => s.IdRol == pUsuario.IdRol);

                if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                    query = query.Where(s => s.Nombre.Contains(pUsuario.Nombre));

                if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                    query = query.Where(s => s.Apellido.Contains(pUsuario.Apellido));

                if (!string.IsNullOrWhiteSpace(pUsuario.Telefono))
                    query = query.Where(s => s.Telefono.Contains(pUsuario.Telefono));

                if (!string.IsNullOrWhiteSpace(pUsuario.Clave))
                    query = query.Where(s => s.Clave.Contains(pUsuario.Clave));

                if (!string.IsNullOrWhiteSpace(pUsuario.Estado))
                    query = query.Where(s => s.Estado == pUsuario.Estado);

                return await query.ToListAsync();
            }
        }
    }
}