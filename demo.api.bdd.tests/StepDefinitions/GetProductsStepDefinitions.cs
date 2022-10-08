using demo.api.Models.V1;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace demo.api.bdd.tests.StepDefinitions
{
    [Binding]
    public class GetProductsStepDefinitions
    {
        private readonly ScenarioContext context;

        public GetProductsStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }
        [Given(@"Get api call product using url '([^']*)'")]
        public async Task GivenGetApiCallProductUsingUrl(string operation)
        {
            var client = new RestClient("http://localhost:8080/api/demo");
            CancellationToken cancellationToken = default;
            var request = new RestRequest(operation)
                    .AddHeader("Content-Type", "application/json")
                    .AddHeader("Accept", "application/json");
            Thread.Sleep(10000);
            try
            {
                var response = await client.GetAsync<IEnumerable<Product>>(request, cancellationToken);

                this.context.Set(response, "products");
            }
            catch (Exception)
            {
               //do nothing
            }
        }

        [Then(@"api should return list of products")]
        public void ThenApiShouldReturnListOfProducts()
        {
            var products = this.context.Get<IEnumerable<Product>>("products");
            Assert.IsInstanceOfType(products, typeof(IEnumerable<Product>));
        }
    }
}
