using demo.api.Data;
using demo.api.Models.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace demo.api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("0.1-dev")]
    public class ProductsController : ControllerBase
    {
   
        private readonly DemoApiDbContext dbContext;

        public ProductsController( DemoApiDbContext dbContext)
        {
         
            this.dbContext = dbContext;
        }
        [HttpGet]
        [MapToApiVersion("0.1-dev")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products= await dbContext.Products.ToListAsync<Product>();
            }
            catch (Exception ex)
            {

                string a = ex.Message;
            }
            return products;
        }

        [HttpPost]
        [MapToApiVersion("0.1-dev")]
        public Task AddProduct(Product product)
        {
            
            try
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                string a = ex.Message;
                return Task.FromException(ex);
            }
            return Task.CompletedTask;
        }
    }
}