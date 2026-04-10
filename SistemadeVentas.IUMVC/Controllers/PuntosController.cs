using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class PuntosController : Controller
    {
        private readonly PuntosBL puntosBL = new PuntosBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Puntos
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var puntos = await puntosBL.ObtenerTodosAsync();
            return View(puntos);
        }

        // GET: Puntos/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Puntos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Puntos puntos)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await puntosBL.CrearAsync(puntos);
                return RedirectToAction(nameof(Index));
            }
            return View(puntos);
        }

        // GET: Puntos/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var puntos = new Puntos { IdPuntos = id };
            var resultado = await puntosBL.BuscarAsync(puntos);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Puntos/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Puntos puntos)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await puntosBL.ModificarAsync(puntos);
                return RedirectToAction(nameof(Index));
            }
            return View(puntos);
        }

        // GET: Puntos/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var puntos = new Puntos { IdPuntos = id };
            var resultado = await puntosBL.BuscarAsync(puntos);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Puntos/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var puntos = new Puntos { IdPuntos = id };
            await puntosBL.EliminarAsync(puntos);
            return RedirectToAction(nameof(Index));
        }

        // GET: Puntos/Buscar
        public async Task<ActionResult> Buscar(Puntos puntos)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var resultado = await puntosBL.BuscarAsync(puntos);
            return View("Index", resultado);
        }

        // POST: Puntos/GenerarCodigoDescuento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GenerarCodigoDescuento(Puntos puntos)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            string codigo = await PuntosBL.GenerarCodigoDescuentoAsync(puntos);
            await puntosBL.ModificarAsync(puntos);
            ViewBag.CodigoGenerado = codigo;
            return View(puntos);
        }

        // POST: Puntos/CanjearPuntos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CanjearPuntos(Puntos puntos)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            bool exito = await PuntosBL.CanjearPuntosAsync(puntos);
            ViewBag.Exito = exito;
            return View(puntos);
        }
    }
}