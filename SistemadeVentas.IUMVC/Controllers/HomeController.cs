using Microsoft.AspNetCore.Mvc;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class HomeController : Controller
    {
        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Home/Index
        public ActionResult Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
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
