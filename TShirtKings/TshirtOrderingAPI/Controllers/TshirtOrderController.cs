using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TshirtOrderingAPI.Api.Data;
using TshirtOrderingAPI.Api.Models;

namespace TshirtOrderingAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TshirtOrderController : ControllerBase
    {
        private readonly ShirtInfo _context;

        public TshirtOrderController(ShirtInfo context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() =>
            _context.Products.ToList();

        // GET by ID action
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST action
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.ID }, product);
        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE action

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}