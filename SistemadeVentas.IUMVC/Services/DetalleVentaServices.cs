using SistemadeVentas.EN;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SistemadeVentas.IUMVC.Services
{
    public class DetalleVentaServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CarritoKey = "Carrito";

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = false
        };

        public DetalleVentaServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public List<DetalleVenta> ObtenerCarrito()
        {
            var json = Session.GetString(CarritoKey);
            return json == null
                ? new List<DetalleVenta>()
                : JsonSerializer.Deserialize<List<DetalleVenta>>(json, _jsonOptions);
        }

        public void AgregarItem(DetalleVenta item)
        {
            var carrito = ObtenerCarrito();
            var existente = carrito.FirstOrDefault(x => x.IdProducto == item.IdProducto);
            if (existente != null)
            {
                existente.Cantidad += item.Cantidad;
                existente.SubTotal = existente.PrecioUnitario * existente.Cantidad;
            }
            else
            {
                item.SubTotal = item.PrecioUnitario * item.Cantidad;
                carrito.Add(item);
            }
            Guardar(carrito);
        }

        public void EliminarItem(int idProducto)
        {
            var carrito = ObtenerCarrito();
            carrito.RemoveAll(x => x.IdProducto == idProducto);
            Guardar(carrito);
        }

        public void ActualizarCantidad(int idProducto, int cantidad)
        {
            var carrito = ObtenerCarrito();
            var item = carrito.FirstOrDefault(x => x.IdProducto == idProducto);
            if (item != null)
            {
                if (cantidad <= 0)
                    carrito.Remove(item);
                else
                {
                    item.Cantidad = cantidad;
                    item.SubTotal = item.PrecioUnitario * cantidad;
                }
            }
            Guardar(carrito);
        }

        public void Limpiar() => Session.Remove(CarritoKey);

        private void Guardar(List<DetalleVenta> carrito) =>
            Session.SetString(CarritoKey, JsonSerializer.Serialize(carrito, _jsonOptions));
    }
}