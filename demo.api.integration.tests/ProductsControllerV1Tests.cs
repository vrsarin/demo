using demo.api.Models.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Net.Http.Json;

namespace demo.api.integration.tests
{
    public class ProductsControllerV1Tests
    {
        private readonly HttpClient client;

        public ProductsControllerV1Tests()
        {

            var testServer = new WebApplicationFactory<Program>().WithWebHostBuilder(conf =>
            {
                conf
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: false);
                    cfg.AddJsonFile("appsettings.test.json", optional: true);
                })
                .UseStartup<Startup>();
            });
            client = testServer.CreateClient();
        }

        [Fact]
        public async void GetProductsEmptyArray()
        {

            var response = await this.client.GetAsync("/v1/products");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();

            // Check if the return type is correct
            Assert.IsAssignableFrom<IEnumerable<Product>>(result);
        }


        [Fact]
        public async void AddProducts()
        {
            var product = new Product
            {
                BasePrice = 43,
                Id = Guid.NewGuid(),
                Name = "Test Product 1",
                SKU = "Testing"
            };
            var response = await this.client.PostAsJsonAsync("/v1/products", product);
            response.EnsureSuccessStatusCode();

            response = await this.client.GetAsync("/v1/products");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            // Check if the return type is correct
            Assert.IsAssignableFrom<IEnumerable<Product>>(result);
            Assert.NotEmpty(result);
            Assert.Contains(result, p => p.Id.Equals(product.Id));
        }
    }
}