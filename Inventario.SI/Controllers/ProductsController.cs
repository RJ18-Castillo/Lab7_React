using Inventario.MODEL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly BL.GestorInventario _gestor;

        public ProductsController(BL.GestorInventario gestor)
        {
            _gestor = gestor;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _gestor.ObtenerProductos();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = _gestor.ObtenerProductoPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }



            _gestor.AgregarProducto(producto);


            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult<Producto> Put(int id, [FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            _gestor.ActualizarProducto(producto);

            return Ok(producto);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producto = _gestor.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }

            _gestor.EliminarProducto(id);

            return NoContent();
        }
    }
}
