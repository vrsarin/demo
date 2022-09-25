using demo.api.Models.V1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNet.OData;

namespace demo.api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("0.1-dev")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("0.1-dev")]
        public IEnumerable<Product> GetProducts()
        {
            return default;
        }
    }
}
