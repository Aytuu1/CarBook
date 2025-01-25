using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
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
    public async Task<IActionResult> GetBrand(int id)
    {
      var values = await _mediator.Send(new GetBrandByIdQuery(id));
      return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommands command)
    {
      await _mediator.Send(command);
      return Ok("Marka bilgisi Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandCommands commands)
    {
      await _mediator.Send(commands);
      return Ok("Marka bilgisi güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBrand(int id)
    {
      await _mediator.Send(new RemoveBrandCommands(id));
      return Ok("Marka bilgileri silindi");
    }







  }
}
