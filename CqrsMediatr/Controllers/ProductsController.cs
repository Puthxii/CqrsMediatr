using CqrsMediatr.Commands;
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

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var products = await _sender.Send(new GetProductByIdQuery(id));

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }
    }
}
