using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemadeVentas.BL;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioBL usuarioBL = new UsuarioBL();
        private readonly RolBL rolBL = new RolBL();

        private bool VerificarSesion()
        {
            return Request.Cookies["UsuarioLogin"] != null;
        }

        private bool VerificarAdmin()
        {
            return Request.Cookies["UsuarioRol"] == "1";
        }

        // GET: Usuario/Login
        public ActionResult Login()
        {
            if (VerificarSesion())
                return RedirectToAction("Index", "Home");

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
                Response.Cookies.Append("UsuarioRol", usuarioEncontrado.IdRol.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(8),
                    HttpOnly = true
                });
                Response.Cookies.Append("UsuarioNombre", usuarioEncontrado.Nombre, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddHours(8),
                    HttpOnly = false
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
            Response.Cookies.Delete("UsuarioRol");
            Response.Cookies.Delete("UsuarioNombre");
            return RedirectToAction("Login", "Usuario");
        }

        // GET: Usuario/Index - solo admin
        public async Task<ActionResult> Index()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var usuarios = await usuarioBL.ObtenerUsuarioAsync();
            return View(usuarios);
        }

        // GET: Usuario/Crear - público para registro
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear(Usuario usuario)
        {
            // Ignorar validación de campos que se asignan automáticamente
            ModelState.Remove("IdRol");
            ModelState.Remove("Estado");
            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Rol");

            if (ModelState.IsValid)
            {
                usuario.IdRol = 3;
                usuario.Estado = "Activo";
                usuario.FechaRegistro = DateTime.Now;
                await usuarioBL.CrearAsync(usuario);
                TempData["Exito"] = "Cuenta creada correctamente.";
                return RedirectToAction("Login", "Usuario");
            }
            return View(usuario);
        }

        // GET: Usuario/CrearAdmin - solo admin
        public async Task<ActionResult> CrearAdmin()
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Roles = new SelectList(roles, "IdRol", "Nombre");
            return View();
        }

        // POST: Usuario/CrearAdmin - solo admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearAdmin(Usuario usuario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Rol");

            if (ModelState.IsValid)
            {
                usuario.FechaRegistro = DateTime.Now;
                await usuarioBL.CrearAsync(usuario);
                TempData["Exito"] = "Usuario creado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            var roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Roles = new SelectList(roles, "IdRol", "Nombre");
            return View(usuario);
        }

        // GET: Usuario/Modificar/5
        public async Task<ActionResult> Modificar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var usuario = new Usuario { IdUsuario = id };
            var resultado = await usuarioBL.BuscarAsync(usuario);
            if (resultado == null)
                return NotFound();

            var roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Roles = new SelectList(roles, "IdRol", "Nombre");
            return View(resultado.FirstOrDefault());
        }

        // POST: Usuario/Modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Modificar(Usuario usuario)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            ModelState.Remove("FechaRegistro");
            ModelState.Remove("Rol");

            if (ModelState.IsValid)
            {
                await usuarioBL.ModificarAsync(usuario);
                TempData["Exito"] = "Usuario modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            var roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Roles = new SelectList(roles, "IdRol", "Nombre");
            return View(usuario);
        }

        // GET: Usuario/Eliminar/5
        public async Task<ActionResult> Eliminar(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var usuario = new Usuario { IdUsuario = id };
            var resultado = await usuarioBL.BuscarAsync(usuario);
            if (resultado == null)
                return NotFound();

            return View(resultado.FirstOrDefault());
        }

        // POST: Usuario/EliminarConfirmado
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarConfirmado(int id)
        {
            if (!VerificarSesion())
                return RedirectToAction("Login", "Usuario");

            if (!VerificarAdmin())
                return RedirectToAction("Index", "Home");

            var usuario = new Usuario { IdUsuario = id };
            await usuarioBL.EliminarAsync(usuario);
            TempData["Exito"] = "Usuario eliminado correctamente.";
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