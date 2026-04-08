using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class RolController : Controller
    {
        private readonly RolBL rolBL = new RolBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Rol
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var roles = await rolBL.ObtenerTodosAsync();
            return View(roles);
        }

        // GET: Rol/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Rol/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Rol rol)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await rolBL.CrearAsync(rol);
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: Rol/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var rol = new Rol { IdRol = id };
            var resultado = await rolBL.ObtenerPorIdAsync(rol);
            if (resultado == null)
                return NotFound();

            return View(resultado);
        }

        // POST: Rol/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Rol rol)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await rolBL.ModificarAsync(rol);
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: Rol/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var rol = new Rol { IdRol = id };
            var resultado = await rolBL.ObtenerPorIdAsync(rol);
            if (resultado == null)
                return NotFound();

            return View(resultado);
        }

        // POST: Rol/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var rol = new Rol { IdRol = id };
            await rolBL.EliminarAsync(rol);
            return RedirectToAction(nameof(Index));
        }

        // GET: Rol/Buscar
        public async Task<ActionResult> Buscar(Rol rol)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var roles = await rolBL.BuscarAsync(rol);
            return View("Index", roles);
        }
    }
}
