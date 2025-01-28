using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/SocialMedias")]
  [ApiController]
  public class SocialMediasController : ControllerBase
  {
    private readonly IMediator _mediator;

    public SocialMediasController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> SocialMediaList()
    {
      var values = await _mediator.Send(new GetSocialMediaQuery());
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSocialMedia([FromRoute] int id)
    {
      var values = await _mediator.Send(new GetSocialMediaByIdQuery(id));
      return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand command)
    {
      await _mediator.Send(command);
      return Ok("Social Media information added successfully ");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommand commands)
    {
      await _mediator.Send(commands);
      return Ok("Social Media information updated successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveSocialMedia([FromRoute] int id)
    {
      await _mediator.Send(new RemoveSocialMediaCommand(id));
      return Ok("Social Media information deleted successfully");
    }

  }
}
