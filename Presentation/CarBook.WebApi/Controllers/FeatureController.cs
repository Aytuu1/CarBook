using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Feature")]
  [ApiController]
  public class FeatureController : ControllerBase
  {
    private readonly IMediator _mediator;

    public FeatureController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> FeatureList()
    {
      var values = await _mediator.Send(new GetFeatureQuery());
      return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFeature([FromRoute] int id)
    {
      var value = await _mediator.Send(new GetFeatureByIdQuery(id));
      return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommand command)
    {
      await _mediator.Send(command);
      return Ok("İnformation succesfully created");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommand command)
    {
      await _mediator.Send(command);
      return Ok("İnformation succesfully updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeature([FromRoute] int id)
    {
      await _mediator.Send(new RemoveFeatureCommand(id));
      return Ok("İnformation succesfully deleted");
    }









  }
}
