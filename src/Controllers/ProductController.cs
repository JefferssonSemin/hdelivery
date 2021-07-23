using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.HDelivery.Data;
using EFCore.HDelivery.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFCore.HDelivery.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get([FromServices] ApplicationContext db )
        {
            var product = db.Products.ToArray();

            return product;
        }
    }
}
