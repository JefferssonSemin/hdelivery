using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Domain;
using str.Data;

namespace EFCore.Multitenant.Controllers
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
