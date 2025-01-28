using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Abouts")]
  [ApiController]
  public class AboutsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public AboutsController(IMediator mediator)
    {
      _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
      var values = await _mediator.Send(new GetAboutQuery());
      return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout([FromRoute]int id)
    {
      var values = await _mediator.Send(new GetAboutByIdQuery(id));
      return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout([FromBody]CreateAboutCommand command)
    {
      await _mediator.Send(command);
      return Ok("About me information was successfully created");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveAbout([FromRoute]int id)
    {
      await _mediator.Send(new RemoveAboutCommand(id));
      return Ok("About me information was successfully deleted");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAbout([FromBody]UpdateAboutCommand command)
    {
      await _mediator.Send(command);
      return Ok("About me information was successfully updated");
    }










  }
}
