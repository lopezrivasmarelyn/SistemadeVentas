using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductoBL productoBL = new ProductoBL();

        public async Task<ActionResult> Index()
        {
            var productos = await productoBL.ObtenerTodosAsync();
            return View(productos);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult AccesoDenegado()
        {
            return View();
        }
    }
}