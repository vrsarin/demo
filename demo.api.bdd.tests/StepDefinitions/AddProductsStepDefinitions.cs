using demo.api.Models.V1;
using RestSharp;
using System.Net;

namespace demo.api.bdd.tests.StepDefinitions
{
    [Binding]
    public class AddProductsStepDefinitions
    {
        private readonly ScenarioContext context;


        public AddProductsStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"The product has a new guid")]
        public void GivenTheProductHasANewGuid()
        {
            this.context.Clear();
            var product = new Product
            {
                Id = Guid.NewGuid()
            };
            this.context.Set(product);
        }

        [Given(@"The product name is '([^']*)'")]
        public void GivenTheProductNameIs(string name)
        {
            var product = this.context.Get<Product>();
            product.Name = name;
            this.context.Set(product);

        }

        [Given(@"The product SKU is '([^']*)'")]
        public void GivenTheProductSKUIs(string sku)
        {
            var product = this.context.Get<Product>();
            product.SKU = sku;
            this.context.Set(product);
        }

        [Given(@"The product BasePrice is  (.*)")]
        public void GivenTheProductBasePriceIs(Decimal basePrice)
        {
            var product = this.context.Get<Product>();
            product.BasePrice = basePrice;
            this.context.Set(product);
        }

        [When(@"Post the product using url '([^']*)'")]
        public async Task WhenPostTheProductUsingUrlAsync(string operation)
        {
            var client = new RestClient("http://localhost:8080/api/demo");
            CancellationToken cancellationToken = default;
            var request = new RestRequest(operation)
                    .AddHeader("Content-Type", "application/json")
                    .AddHeader("Accept", "application/json")
                    .AddJsonBody(this.context.Get<Product>());
            var response = await client.PostAsync(request, cancellationToken);
            Thread.Sleep(10000);
            try
            {
                this.context.Set(response.StatusCode, "ResponseStatusCode");
            }
            catch (Exception)
            {
                this.context.Set(HttpStatusCode.InternalServerError, "ResponseStatusCode");
            }
        }

        [Then(@"api should return httpstatuscode (.*)")]
        public void ThenApiShouldReturnHttpstatuscode(int statusCode)
        {
            int status = (int)context.Get<HttpStatusCode>("ResponseStatusCode");
            Assert.AreEqual(statusCode, status);
        }
    }
}
