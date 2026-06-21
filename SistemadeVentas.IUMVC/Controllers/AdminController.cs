using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class AdminController : Controller
    {
        private bool VerificarAdmin()
        {
            return Request.Cookies["UsuarioLogin"] != null &&
                   Request.Cookies["UsuarioRol"] == "1"; // IdRol 1 = Administrador
        }

        public ActionResult Index()
        {
            if (!VerificarAdmin())
                return RedirectToAction("Login", "Usuario");

            return View();
        }
    }
}