using demo.api.Models.V1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNet.OData;

namespace demo.api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1-dev")]
  public class ProductsController : ODataController
    {
        [HttpGet]
        [MapToApiVersion("1.0")]

        //[Obsolete("Will be removed in version 2.0")]
        public IEnumerable<Product> GetProducts()
        {
            return null;
        }

        [HttpGet]
        [MapToApiVersion("1.1-dev")]

        //[Obsolete("Will be removed in version 2.0")]
        public IEnumerable<Product> GetProductsV1()
        {
            return null;
        }
    }
}
