using Microsoft.AspNetCore.Mvc;
using SistemadeVentas.IUMVC.Services;
using SistemadeVentas.EN;

namespace SistemadeVentas.IUMVC.Controllers
{
    public class DetalleVentaController : Controller
    {
        private readonly DetalleVentaServices _detalleVentaServices;

        public DetalleVentaController(DetalleVentaServices detalleVentaServices)
        {
            _detalleVentaServices = detalleVentaServices;
        }

        public IActionResult Index()
        {
            var carrito = _detalleVentaServices.ObtenerCarrito();
            return View(carrito);
        }

        [HttpPost]
        public IActionResult Agregar(int IdProducto, string nombreProducto,
                                     int Cantidad, decimal PrecioUnitario, decimal SubTotal = 1)
        {
            _detalleVentaServices.AgregarItem(new DetalleVenta
            {
                IdProducto = IdProducto,
                Cantidad = Cantidad,
                PrecioUnitario = PrecioUnitario,
                SubTotal = PrecioUnitario * Cantidad,
                Producto = new Producto { IdProducto = IdProducto, Nombre = nombreProducto }
            });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int IdProducto)
        {
            _detalleVentaServices.EliminarItem(IdProducto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ActualizarCantidad(int IdProducto, int cantidad)
        {
            _detalleVentaServices.ActualizarCantidad(IdProducto, cantidad);
            return RedirectToAction("Index");
        }
    }
}