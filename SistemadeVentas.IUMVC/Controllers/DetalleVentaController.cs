using Microsoft.AspNetCore.Mvc;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class DetalleVentaController : Controller
    {
        // GET: DetalleVenta
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetalleVenta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleVenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleVenta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleVenta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalleVenta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DetalleVenta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetalleVenta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}