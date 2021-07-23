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
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Store> Get([FromServices] ApplicationContext db )
        {
            var store = db.Store.ToArray();

            return store;
        }
    }
}
