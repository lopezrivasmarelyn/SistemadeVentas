using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBL productoBL = new ProductoBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Producto
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var productos = await productoBL.ObtenerTodosAsync();
            return View(productos);
        }

        // GET: Producto/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Producto/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Producto producto)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await productoBL.CrearAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var producto = new Producto { IdProducto = id };
            var resultado = await productoBL.BuscarAsync(producto);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Producto/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Producto producto)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await productoBL.ModificarAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var producto = new Producto { IdProducto = id };
            var resultado = await productoBL.BuscarAsync(producto);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Producto/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var producto = new Producto { IdProducto = id };
            await productoBL.EliminarAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Producto/Buscar
        public async Task<ActionResult> Buscar(Producto producto)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var productos = await productoBL.BuscarAsync(producto);
            return View("Index", productos);
        }

        // POST: Producto/ActualizarPrecio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarPrecio(Producto producto)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            await productoBL.ActualizarPrecioAsync(producto);
            return RedirectToAction(nameof(Index));
        }
    }
}