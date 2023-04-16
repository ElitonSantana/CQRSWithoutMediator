using CQRSWithoutMediator.Domain.Commands.Requests;
using CQRSWithoutMediator.Domain.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithoutMediator.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public IActionResult CreateProduct(
            [FromServices] ICreateProductHandler handler,
            [FromBody] CreateProductRequestCommand command
            )
        {
            //Implementation on request for layer Domain send handler, command parameter
            handler.sendHandler(command);


            return Ok(true);
        }
    }
}
