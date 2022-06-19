using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProductInventory.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ProductController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), 200)]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        [Route("search/{name}")]
        [ProducesResponseType(typeof(Product), 200)]
        public async Task<IActionResult> Search([FromRoute] string name)
        {
            // var product = await _context.Products.FirstOrDefaultAsync(x => x.Name.Contains(name));
            // if (product == null)
            //     return NotFound();

            // return Ok(product);
            
            List<string> QueriedProducts = new List<string>();
            var products = await _context.Products.Where(x => x.Name.Contains(name)).ToListAsync();

            // foreach (var product in _context.Products.Where(x => x.Name.Contains(name)))
            // {
            //     QueriedProducts.Add(product.Name);
            //     QueriedProducts.Add(product.Description);
                
            // }
            // string jsonString = JsonSerializer.Serialize(QueriedProducts);
            return Ok(products);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            var existing = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if (existing == null)
                return NotFound();

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;

            _context.Update(existing);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            _context.Add(product);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return NotFound();

            _context.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}