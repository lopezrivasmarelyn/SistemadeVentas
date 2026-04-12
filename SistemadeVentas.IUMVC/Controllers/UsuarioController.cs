using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.BL;
using SistemadeVentas.EN;



namespace SistemadeVentas.IUMVC.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly UsuarioBL usuarioBL = new UsuarioBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        // GET: Usuario/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Usuario/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Usuario usuario)
        {
            var buscar = new Usuario
            {
                Telefono = usuario.Telefono,
                Clave = usuario.Clave
            };

            var resultado = await usuarioBL.BuscarAsync(buscar);
            var usuarioEncontrado = resultado.FirstOrDefault();

            if (usuarioEncontrado != null)
            {
                Response.Cookies.Append("UsuarioLogin", usuarioEncontrado.IdUsuario.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(8),
                    HttpOnly = true
                });

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Teléfono o contraseña incorrectos.";
            return View();
        }

        // GET: Usuario/Logout
        public ActionResult Logout()
        {
            Response.Cookies.Delete("UsuarioLogin");
            return RedirectToAction("Login", "Usuario");
        }

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var usuarios = await usuarioBL.ObtenerUsuarioAsync();
            return View(usuarios);
        }

        // GET: Usuario/Crear
        public ActionResult Crear()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            return View();
        }

        // POST: Usuario/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Usuario usuario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await usuarioBL.CrearAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var usuario = new Usuario { IdUsuario = id };
            var resultado = await usuarioBL.BuscarAsync(usuario);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Usuario/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Usuario usuario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (ModelState.IsValid)
            {
                await usuarioBL.ModificarAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var usuario = new Usuario { IdUsuario = id };
            var resultado = await usuarioBL.BuscarAsync(usuario);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Usuario/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var usuario = new Usuario { IdUsuario = id };
            await usuarioBL.EliminarAsync(usuario);
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuario/Buscar
        public async Task<ActionResult> Buscar(Usuario usuario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            var usuarios = await usuarioBL.BuscarAsync(usuario);
            return View("Index", usuarios);
        }
    }
}