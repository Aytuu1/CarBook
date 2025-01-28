using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Features.Mediator.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Category")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
      var values = await _mediator.Send(new GetCategoryQuery());
      return Ok(values);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
      var value = await _mediator.Send(new GetCategoryByIdQuery(id));
      return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
      await _mediator.Send(command);
      return Ok("Created succesfully category");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
    {
      await _mediator.Send(command);
      return Ok("Updated succesfully category");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCategory([FromRoute] int id)
    {
      await _mediator.Send(new RemoveCategoryCommand(id));
      return Ok("Deleted succesfully category");
    }

  }
}
