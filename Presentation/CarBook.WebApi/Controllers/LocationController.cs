using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationController : ControllerBase
  {
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> LocationList()
    {
      var value = await _mediator.Send(new GetLocationQuery());
      return Ok(value);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocation([FromRoute] int id)
    {
      var value = await _mediator.Send(new GetLocationByIdQuery(id));
      return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
    {
      await _mediator.Send(command);
      return Ok("Location information added");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveLocation([FromRoute] int id)
    {
      await _mediator.Send(new RemoveLocationCommand(id));
      return Ok("Location information deleted");
    }

  }
}
