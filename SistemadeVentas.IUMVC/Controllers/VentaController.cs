using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class VentaController : Controller
    {
        private readonly VentaBL ventaBL = new VentaBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Venta
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var ventas = await ventaBL.ObtenerTodosAsync();
            return View(ventas);
        }

        // GET: Venta/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Venta/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Venta venta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await ventaBL.CrearAsync(venta);
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // GET: Venta/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var venta = new Venta { IdVenta = id };
            var resultado = await ventaBL.BuscarAsync(venta);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Venta/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Venta venta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await ventaBL.ModificarAsync(venta);
                return RedirectToAction(nameof(Index));
            }
            return View(venta);
        }

        // GET: Venta/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var venta = new Venta { IdVenta = id };
            var resultado = await ventaBL.BuscarAsync(venta);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Venta/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var venta = new Venta { IdVenta = id };
            await ventaBL.EliminarAsync(venta);
            return RedirectToAction(nameof(Index));
        }

        // GET: Venta/Buscar
        public async Task<ActionResult> Buscar(Venta venta)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var ventas = await ventaBL.BuscarAsync(venta);
            return View("Index", ventas);
        }

        // GET: Venta/CalcularTotal/5
        public async Task<ActionResult> CalcularTotal(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var venta = new Venta { IdVenta = id };
            var resultado = await ventaBL.BuscarAsync(venta);
            var ventaEncontrada = resultado.FirstOrDefault();

            if (ventaEncontrada == null)
                return NotFound();

            decimal total = await VentaBL.CalcularTotalAsync(ventaEncontrada);
            ViewBag.Total = total;
            return View(ventaEncontrada);
        }
    }
}