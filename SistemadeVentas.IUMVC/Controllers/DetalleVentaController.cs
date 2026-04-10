using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class DetalleVentaController : Controller
    {
        private readonly DetalleVentaBL detalleVentaBL = new DetalleVentaBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: DetalleVenta
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var detalles = await detalleVentaBL.ObtenerTodosAsync();
            return View(detalles);
        }

        // GET: DetalleVenta/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: DetalleVenta/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(DetalleVenta detalleVenta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await detalleVentaBL.CrearAsync(detalleVenta);
                return RedirectToAction(nameof(Index));
            }
            return View(detalleVenta);
        }

        // GET: DetalleVenta/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var detalle = new DetalleVenta { IdDetalleVenta = id };
            var resultado = await detalleVentaBL.BuscarAsync(detalle);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: DetalleVenta/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(DetalleVenta detalleVenta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await detalleVentaBL.ModificarAsync(detalleVenta);
                return RedirectToAction(nameof(Index));
            }
            return View(detalleVenta);
        }

        // GET: DetalleVenta/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var detalle = new DetalleVenta { IdDetalleVenta = id };
            var resultado = await detalleVentaBL.BuscarAsync(detalle);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: DetalleVenta/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var detalle = new DetalleVenta { IdDetalleVenta = id };
            await detalleVentaBL.EliminarAsync(detalle);
            return RedirectToAction(nameof(Index));
        }

        // GET: DetalleVenta/Buscar
        public async Task<ActionResult> Buscar(DetalleVenta detalleVenta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var detalles = await detalleVentaBL.BuscarAsync(detalleVenta);
            return View("Index", detalles);
        }

        // POST: DetalleVenta/CalcularSubtotal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CalcularSubtotal(DetalleVenta detalleVenta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            decimal subtotal = await detalleVentaBL.CalcularSubtotalAsync(detalleVenta);
            ViewBag.Subtotal = subtotal;
            return View(detalleVenta);
        }
    }
}