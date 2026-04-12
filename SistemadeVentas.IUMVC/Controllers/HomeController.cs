using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductoBL productoBL = new ProductoBL();

        // GET: Home/Index - Tienda pública (sin login)
        public async Task<ActionResult> Index()
        {
            var productos = await productoBL.ObtenerTodosAsync();
            return View(productos);
        }

        // GET: Home/Error
        public ActionResult Error()
        {
            return View();
        }

        // GET: Home/AccesoDenegado
        public ActionResult AccesoDenegado()
        {
            return View();
        }
    }
}