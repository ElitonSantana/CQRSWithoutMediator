using CQRSWithoutMediator.Domain.Services.Interfaces;
using CQRSWithoutMediator.Infra.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithoutMediator.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var result = _productService.CreateAsync(product).Result;

            if (!result.isSuccessful)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
