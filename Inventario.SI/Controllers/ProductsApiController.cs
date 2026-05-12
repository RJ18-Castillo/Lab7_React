using Inventario.MODEL;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsApiController : ControllerBase
    {
        private readonly BL.GestorInventario _gestor;

        public ProductsApiController(BL.GestorInventario gestor)
        {
            _gestor = gestor;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return Ok(_gestor.ObtenerProductos());
        }
    }
}