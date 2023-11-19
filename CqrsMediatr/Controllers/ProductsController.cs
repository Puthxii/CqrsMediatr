using CqrsMediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatr.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());

            return Ok(products);
        }
    }
}
