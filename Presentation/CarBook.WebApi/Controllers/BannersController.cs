using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Banners")]
  [ApiController]
  public class BannersController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BannersController(IMediator mediator)
    {
      _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
      var values = await _mediator.Send(new GetBannerQuery());
      return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner([FromRoute] int id)
    {
      var value = await _mediator.Send(new GetBannerByIdQuery(id));
      return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommands commands)
    {
      await _mediator.Send(commands);
      return Ok("Created succesfully information");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBanner([FromBody] UpdateBannerCommand command)
    {
      await _mediator.Send(command);
      return Ok("Updated succesfully information");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBanner([FromRoute] int id)
    {
      await _mediator.Send(new RemoveBannerCommand(id));
      return Ok("Deleted succesfully information");
    }














  }
}
