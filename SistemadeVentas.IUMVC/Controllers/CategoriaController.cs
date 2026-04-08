using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaBL categoriaBL = new CategoriaBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Categoria
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var categorias = await categoriaBL.ObtenerTodosAsync();
            return View(categorias);
        }

        // GET: Categoria/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Categoria/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Categoria categoria)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await categoriaBL.CrearAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var categoria = new Categoria { IdCategoria = id };
            var resultado = await categoriaBL.BuscarAsync(categoria);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Categoria/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Categoria categoria)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await categoriaBL.ModificarAsync(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categoria/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var categoria = new Categoria { IdCategoria = id };
            var resultado = await categoriaBL.BuscarAsync(categoria);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Categoria/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var categoria = new Categoria { IdCategoria = id };
            await categoriaBL.EliminarAsync(categoria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categoria/Buscar
        public async Task<ActionResult> Buscar(Categoria categoria)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var categorias = await categoriaBL.BuscarAsync(categoria);
            return View("Index", categorias);
        }
    }
}