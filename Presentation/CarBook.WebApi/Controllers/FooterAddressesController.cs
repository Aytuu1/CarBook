using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FooterAddressesController : ControllerBase
  {
    private readonly IMediator _mediator;

    public FooterAddressesController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> FooterAddressesList()
    {
      var value = await _mediator.Send(new GetFooterAddressQuery());
      return Ok(value);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFooterAddresses([FromRoute] int id)
    {
      var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
      return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateFooterAddresses(CreateFooterAddressCommand command)
    {
      await _mediator.Send(command);
      return Ok("Alt adres bilgisi eklendi");

    }
    [HttpPut]
    public async Task<IActionResult> UpdateFooterAddresses(UpdateFooterAddressCommand command)
    {
      await _mediator.Send(command);
      return Ok("Alt adres bilgisi güncellendi");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFooterAddresses([FromRoute] int id)
    {
      await _mediator.Send(new RemoveFooterAddressCommand(id));
      return Ok("Alt adres bilgisi silindi");
    }


  }
}
