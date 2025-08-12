using Application.DTOs;
using Application.UseCases.Commands.CreateProduct;
using Application.UseCases.Commands.DeleteProduct;
using Application.UseCases.Commands.UpdateProduct;
using Application.UseCases.Queries.GetAllProducts;
using Application.UseCases.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {

            var product = await mediator.Send(new GetProductByIdQuery(id));
            if (product == null) return NotFound($"Product with id {id} not found.");
            return Ok(product);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto body)
        {
            try
            {
                await mediator.Send(new CreateProductCommand(body.Name, body.Description, body.Price, body.InStock, body.Sku, body.Slug));
                return Created();
            }
            catch
            {
                return BadRequest("An error occurred while creating the product.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto product)
        {
            if (id == Guid.Empty) return BadRequest("Invalid product ID.");

            var updated = await mediator.Send(new UpdateProductCommand(product, id));

            if (!updated) return NotFound($"Product with id {id} not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Invalid product ID.");
            var deleted = await mediator.Send(new DeleteProductCommand(id));
            if (!deleted) return NotFound($"Product with id {id} not found.");
            return NoContent();
        }
    }
}
