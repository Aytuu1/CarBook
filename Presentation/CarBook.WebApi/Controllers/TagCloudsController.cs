
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/TagClouds")]
  [ApiController]
  public class TagCloudsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public TagCloudsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> TagCloudList()
    {
      var tagCloudList = await _mediator.Send(new GetTagCloudQuery());
      return Ok(tagCloudList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagCloud([FromRoute] int id)
    {
      var getTagCloud = await _mediator.Send(new GetTagCloudByIdQuery(id));
      return Ok(getTagCloud);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTagCloud([FromRoute] int id)
    {
      await _mediator.Send(new RemoveTagCloudCommand(id));
      return Ok("TagCloud removed Succesfully ");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTagCloud([FromBody] UpdateTagCloudCommand command)
    {
      await _mediator.Send(command);
      return Ok("TagCloud updated succesfully");
    }

    [HttpPost]
    public async Task<IActionResult> CreateTagCloud([FromBody] CreateTagCloudCommand command)
    {
      await _mediator.Send(command);
      return Ok("TagCloud created succesfully");
    }

    [HttpGet("getTagCloudByBlogId/{id}")]
    public async Task<IActionResult> getTagCloudByBlogId([FromRoute] int id)
    {
      var value = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
      return Ok(value);

    }














  }
}
