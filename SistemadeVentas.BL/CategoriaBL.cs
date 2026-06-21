//Referencias
using System.Security.Cryptography;
//referencias del proyedcto
using SistemadeVentas.EN;
using SistemadeVentas.DAL;

namespace SistemadeVentas.BL
{
    public class CategoriaBL
    {
        public async Task<int> CrearAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.CrearAsync(pCategoria);
        }

        public async Task<int> ModificarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.ModificarAsync(pCategoria);
        }

        public async Task<int> EliminarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.EliminarAsync(pCategoria);
        }

        public async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            return await CategoriaDAL.BuscarAsync(pCategoria);
        }

        public async Task<List<Categoria>> ObtenerTodosAsync()
        {
            return await CategoriaDAL.ObtenerTodosAsync();
        }
    }
}