using CQRSWithoutMediator.Domain.Commands.Requests;
using CQRSWithoutMediator.Domain.Entities;
using CQRSWithoutMediator.Domain.Handlers.Interfaces;
using CQRSWithoutMediator.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithoutMediator.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateProduct(
            [FromServices] ICreateProductHandler handler,
            [FromBody] CreateProductRequestCommand command
            )
        {


            _productRepository.CreateAsync(new Product
            {
                Name = "Coca-Cola",
                Description = "Refrigerante",
                Price = 10,
                ProductId = 2
            });

            //Implementation on request for layer Domain send handler, command parameter
            //handler.sendHandler(command,);


            return Ok(true);
        }
    }
}
