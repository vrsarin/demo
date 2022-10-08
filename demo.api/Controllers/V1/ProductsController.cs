using demo.api.Data;
using demo.api.Models.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class ProductsController : ControllerBase
    {

        private readonly DemoApiDbContext dbContext;

        public ProductsController(DemoApiDbContext dbContext)
        {

            this.dbContext = dbContext;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync<Product>();
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> AddProduct(Product product)
        {

            try
            {
                if (await dbContext.Products.Where(p => p.Id.Equals(product.Id)).AnyAsync())
                {
                    return BadRequest($"Product with Id={product.Id} already exist");
                }
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok();
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateProduct(Guid id, Product product)
        {

            try
            {
                if (await dbContext.Products.Where(p => p.Id.Equals(id)).AnyAsync())
                {
                    return NotFound($"Product with Id={id} not found");
                }
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Ok();
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var dbData = dbContext.Products.Where(p => p.Id.Equals(id));
                var recordsFound = dbData.Count();
                if (recordsFound.Equals(0))
                {
                    return NoContent();
                }
                else if (recordsFound > 1)
                {
                    return Problem($"There was some problem deleting the product with ID='{id}'");
                }
                dbContext.Products.Remove(dbData.Single());
                await dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception)
            {
                return Problem($"There was some problem deleting the product with ID='{id}'");
            }
        }

    }
}