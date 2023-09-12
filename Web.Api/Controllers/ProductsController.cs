using Application.Features.Product.Commands;
using Application.Features.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProductsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet("Products")]
	public async Task<IActionResult> GetProducts(CancellationToken cancellation)
	{
		var result = await _mediator.Send(new GetAllProductsQuery(), cancellation);
		return Ok(result);
	}

    [HttpGet("Product/{id}")]
    public async Task<IActionResult> GetProductById(int id, CancellationToken cancellation)
    {
        var result = await _mediator.Send(new GetSingleProductQuery { Id = id}, cancellation);
        return Ok(result);
    }

    [HttpPost ("NewProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductCommand createProduct,CancellationToken cancellation)
    {
        var result = await _mediator.Send(createProduct, cancellation);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProduct, CancellationToken cancellation)
    {
        var result = await _mediator.Send(updateProduct, cancellation);
        return Ok(result);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellation)
    {
        var result = await _mediator.Send(new DeleteProductCommand { Id = id }, cancellation);
        return Ok(result);
    }
}
