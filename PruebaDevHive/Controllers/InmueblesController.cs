using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaDevHive.Models;
using PruebaDevHive.Repository;
using PruebaDevHive.Services;

namespace PruebaDevHive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmueblesController : ControllerBase
    {
        private readonly IGenericService<Inmueble, InmueblesDevHiveContext> _productoService;

        public InmueblesController(IGenericService<Inmueble, InmueblesDevHiveContext> productoService,
            IGenericRepository<Inmueble, InmueblesDevHiveContext> repository)
        {
            _productoService = productoService;
        }

        [HttpGet("stored")]
        public async Task<ActionResult<IEnumerable<Inmueble>>> GetInmueblesFromStoredProcedure()
        {
            var inmuebles = await _productoService.GetAllFromStoredProcedureAsync("GetAllInmuebles");
            if (inmuebles != null)
                return Ok(inmuebles);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inmueble>>> GetProductos()
        {
            var productos = await _productoService.GetAllAsync();
            if (productos != null)
                return Ok(productos);
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inmueble>> GetProducto(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Inmueble>> PostProducto(Inmueble producto)
        {
            var createdProducto = await _productoService.CreateAsync(producto);
            return CreatedAtAction("GetProducto", new { id = createdProducto.Id }, createdProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Inmueble producto)
        {
            producto.Id = id;
            if (id != producto.Id)
            {
                return BadRequest();
            }

            var updated = await _productoService.UpdateAsync(id, producto);
            if (!updated)
            {
                return NotFound();
            }

            return Ok(updated);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var deleted = await _productoService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpOptions]
        public IActionResult Options()
        {
            // Utiliza la política CORS definida en tu program.cs
            Response.Headers.Add("Access-Control-Allow-Origin", "_myAllowSpecificOrigins");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

            // Devuelve una respuesta 200 OK para indicar que la solicitud OPTIONS fue exitosa
            return Ok();
        }

    }
}
