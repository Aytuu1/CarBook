using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Brands")]
  [ApiController]
  public class BrandsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
      var values = await _mediator.Send(new GetBrandQuery());
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand([FromRoute] int id)
    {
      var values = await _mediator.Send(new GetBrandByIdQuery(id));
      return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommands command)
    {
      await _mediator.Send(command);
      return Ok("Created information brand");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommands commands)
    {
      await _mediator.Send(commands);
      return Ok("Updated information brand");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBrand([FromRoute] int id)
    {
      await _mediator.Send(new RemoveBrandCommands(id));
      return Ok("Deleted information brand");
    }







  }
}
