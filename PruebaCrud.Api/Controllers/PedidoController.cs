using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCrud.Api.Model;
using System;
using System.Threading.Tasks;

namespace PruebaCrud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly CrudContext _context;

        public PedidoController(CrudContext context)
        {
            _context = context;
        }

        [HttpGet("{id}", Name = "GetPedido")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
                if (result == null)
                    return NotFound();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _context.Pedidos.ToListAsync();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Pedido data)
        {
            try
            {
                _context.Pedidos.Add(data);
                await _context.SaveChangesAsync();
                return Created("Get", data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromForm]Pedido data)
        {
            try
            {
                var toUpdate = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
                if (toUpdate == null)
                    return NotFound();

                toUpdate.Descripcion = data.Descripcion;
                toUpdate.Producto = data.Producto;

                _context.Pedidos.Update(toUpdate);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var toDelete = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
                if (toDelete == null)
                    return NotFound();

                _context.Pedidos.Remove(toDelete);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }


}