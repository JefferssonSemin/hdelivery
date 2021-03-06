using System.Threading.Tasks;
using EFCore.HDelivery.Data.Repositories;
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
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(ILogger<ProductController> logger, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var products = await _productRepository.GetByIdAsync(id);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productRepository.Add(product);
            var saved = _unitOfWork.Commit();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            _productRepository.Remove(product);

            _unitOfWork.Commit();

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> SearchProductAsync([FromQuery] string description)
        {
            var product = await _productRepository
                .GetDataAsync(
                    p => p.Description.Contains(description),
                    take: 2);

            return Ok(product);
        }
    }
}