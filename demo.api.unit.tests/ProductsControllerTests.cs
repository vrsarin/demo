using demo.api.Controllers.V1;
using demo.api.Data;
using demo.api.Models.V1;
using Microsoft.EntityFrameworkCore;

namespace demo.api.unit.tests
{
    public class ProductsControllerV1Tests
    {

        private readonly DemoApiDbContext dbContext;

        public ProductsControllerV1Tests()
        {
            dbContext = new DemoApiDbContext(new DbContextOptionsBuilder().UseInMemoryDatabase("LOCAL-DB").Options);
        }

        [Fact]
        public async Task GetProductsEmptyArray()
        {

            var productController = new ProductsController(dbContext);
    
            var products = await productController.GetProducts();
            // Check if the return type is correct
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);

        }


        [Fact]
        public async Task AddProducts()
        {
            var productController = new ProductsController(dbContext);
            await productController.AddProduct(new Product
            {
                BasePrice = 43,
                Id = Guid.NewGuid(),
                Name = "Test Product 1",
                SKU = "Testing"
            });

            var products = await productController.GetProducts();

            // Check if the return type is correct
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
            Assert.NotEmpty(products);
            Assert.Single(products);
            Assert.Collection<Product>(products, p => p.SKU = "Testing");
        }
    }
}