using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
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
    public async Task<IActionResult> GetBanner(int id)
    {
      var value = await _mediator.Send(new GetBannerByIdQuery(id));
      return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBanner(CreateBannerCommands commands)
    {
      await _mediator.Send(commands);
      return Ok("Bilgi Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
    {
      await _mediator.Send(command);
      return Ok("Bilgi güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBanner(int id)
    {
      await _mediator.Send(new RemoveBannerCommand(id));
      return Ok("Bilgi Silindi");
    }














  }
}
