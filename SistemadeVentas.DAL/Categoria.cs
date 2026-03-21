using Microsoft.EntityFrameworkCore;
using SistemadeVentas.EN;

namespace SistemadeVentas.DAL
{
    public class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pCategoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var categoria = await dbContexto.Categoria
                    .FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);

                categoria.Nombre = pCategoria.Nombre;
                categoria.Descripcion = pCategoria.Descripcion;
                categoria.Estado = pCategoria.Estado;

                dbContexto.Update(categoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var categoria = await dbContexto.Categoria
                    .FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);

                dbContexto.Categoria.Remove(categoria);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Categoria> ObtenerPorIdAsync(Categoria pCategoria)
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Categoria
                    .FirstOrDefaultAsync(s => s.IdCategoria == pCategoria.IdCategoria);
            }
        }

        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Categoria.ToListAsync();
            }
        }

        public static async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            using (var dbContexto = new DBContexto())
            {
                var query = dbContexto.Categoria.AsQueryable();

                if (pCategoria.IdCategoria > 0)
                    query = query.Where(s => s.IdCategoria == pCategoria.IdCategoria);

                if (!string.IsNullOrWhiteSpace(pCategoria.Nombre))
                    query = query.Where(s => s.Nombre.Contains(pCategoria.Nombre));

                if (!string.IsNullOrWhiteSpace(pCategoria.Estado))
                    query = query.Where(s => s.Estado == pCategoria.Estado);

                return await query.ToListAsync();
            }
        }
    }
}