using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBL productoBL = new ProductoBL();
        private readonly CategoriaBL categoriaBL = new CategoriaBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        private bool VerificarAdmin()
        {
            return Request.Cookies["UsuarioRol"] == "1";
        }

        // GET: Producto - público
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var productos = await productoBL.ObtenerTodosAsync();
            return View(productos);
        }

        // GET: Producto/Crear
        public async Task<ActionResult> Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var categorias = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre");
            return View();
        }

        // POST: Producto/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Producto producto)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            ModelState.Remove("Categoria");
            ModelState.Remove("ImagenUrl");

            if (ModelState.IsValid)
            {
                await productoBL.CrearAsync(producto);
                TempData["Exito"] = "Producto creado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            var categorias = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre");
            return View(producto);
        }

        // GET: Producto/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var producto = new Producto { IdProducto = id };
            var resultado = await productoBL.BuscarAsync(producto);
            if (resultado == null)
                return NotFound();

            var categorias = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre");
            return View(resultado.FirstOrDefault());
        }

        // POST: Producto/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Producto producto)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            ModelState.Remove("Categoria");
            ModelState.Remove("ImagenUrl");

            if (ModelState.IsValid)
            {
                await productoBL.ModificarAsync(producto);
                TempData["Exito"] = "Producto modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            var categorias = await categoriaBL.ObtenerTodosAsync();
            ViewBag.Categorias = new SelectList(categorias, "IdCategoria", "Nombre");
            return View(producto);
        }

        // GET: Producto/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var producto = new Producto { IdProducto = id };
            var resultado = await productoBL.BuscarAsync(producto);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Producto/EliminarConfirmado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var producto = new Producto { IdProducto = id };
            await productoBL.EliminarAsync(producto);
            TempData["Exito"] = "Producto eliminado correctamente.";
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
    }
}