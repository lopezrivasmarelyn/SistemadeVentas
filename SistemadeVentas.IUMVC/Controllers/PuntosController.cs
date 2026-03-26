using Microsoft.AspNetCore.Mvc;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class PuntosController : Controller
    {
        // GET: Puntos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Puntos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Puntos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puntos/Create
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

        // GET: Puntos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Puntos/Edit/5
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

        // GET: Puntos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Puntos/Delete/5
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