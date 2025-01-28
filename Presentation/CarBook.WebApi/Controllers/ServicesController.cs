using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Services")]
  [ApiController]
  public class ServicesController : ControllerBase
  {
    private readonly IMediator _mediator;

    public ServicesController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
      var values = await _mediator.Send(new GetServiceQuery());
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetService([FromRoute] int id)
    {
      var values = await _mediator.Send(new GetServiceByIdQuery(id));
      return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
    {
      await _mediator.Send(command);
      return Ok("Created information Service");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand commands)
    {
      await _mediator.Send(commands);
      return Ok("updated information Service");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveService([FromRoute] int id)
    {
      await _mediator.Send(new RemoveServiceCommand(id));
      return Ok("Deleted information Service");
    }






  }
}
