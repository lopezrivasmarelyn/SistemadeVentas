using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class InventarioController : Controller
    {
        private readonly InventarioBL inventarioBL = new InventarioBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Inventario
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var inventarios = await inventarioBL.ObtenerTodosAsync();
            return View(inventarios);
        }

        // GET: Inventario/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Inventario/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Inventario inventario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await inventarioBL.CrearAsync(inventario);
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: Inventario/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var inventario = new Inventario { IdInventario = id };
            var resultado = await inventarioBL.BuscarAsync(inventario);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Inventario/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Inventario inventario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await inventarioBL.ModificarAsync(inventario);
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: Inventario/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var inventario = new Inventario { IdInventario = id };
            var resultado = await inventarioBL.BuscarAsync(inventario);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Inventario/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var inventario = new Inventario { IdInventario = id };
            await inventarioBL.EliminarAsync(inventario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Inventario/Buscar
        public async Task<ActionResult> Buscar(Inventario inventario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var inventarios = await inventarioBL.BuscarAsync(inventario);
            return View("Index", inventarios);
        }

        // POST: Inventario/ActualizarStock
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarStock(Inventario inventario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            await InventarioBL.ActualizarStockAsync(inventario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Inventario/VerificarStockMinimo/5
        public async Task<ActionResult> VerificarStockMinimo(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var inventario = new Inventario { IdInventario = id };
            bool stockBajo = await InventarioBL.VerificarStockMinimoAsync(inventario);
            ViewBag.StockBajo = stockBajo;
            return View();
        }
    }
}