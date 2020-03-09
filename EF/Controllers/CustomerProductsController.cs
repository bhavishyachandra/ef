using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BhavisProducts;

namespace BhavisProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductsController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerProductsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/CustomerProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerProduct>>> GetCustomerProducts()
        {
            return await _context.CustomerProducts.ToListAsync();
        }

        // GET: api/CustomerProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerProduct>> GetCustomerProduct(int id)
        {
            var customerProduct = await _context.CustomerProducts.FindAsync(id);

            if (customerProduct == null)
            {
                return NotFound();
            }

            return customerProduct;
        }

        // PUT: api/CustomerProducts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerProduct(int id, CustomerProduct customerProduct)
        {
            if (id != customerProduct.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerProducts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CustomerProduct>> PostCustomerProduct(CustomerProduct customerProduct)
        {
            _context.CustomerProducts.Add(customerProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerProductExists(customerProduct.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerProduct", new { id = customerProduct.CustomerId }, customerProduct);
        }

        // DELETE: api/CustomerProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerProduct>> DeleteCustomerProduct(int id)
        {
            var customerProduct = await _context.CustomerProducts.FindAsync(id);
            if (customerProduct == null)
            {
                return NotFound();
            }

            _context.CustomerProducts.Remove(customerProduct);
            await _context.SaveChangesAsync();

            return customerProduct;
        }

        private bool CustomerProductExists(int id)
        {
            return _context.CustomerProducts.Any(e => e.CustomerId == id);
        }
    }
}
