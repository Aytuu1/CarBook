using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Authors")]
  [ApiController]
  public class AuthorsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> AuthorList()
    {
      var AuthorToList = await _mediator.Send(new GetAuthorQuery());
      return Ok(AuthorToList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor([FromRoute] int id)
    {
      var getToAuthor = await _mediator.Send(new GetAuthorByIdQuery(id));
      return Ok(getToAuthor);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
    {
      await _mediator.Send(command);
      return Ok("Author information Updated");
    }
    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
    {
      await _mediator.Send(command);
      return Ok(" Author  Succesfully Created");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAuthor([FromRoute] int id)
    {
      await _mediator.Send(new RemoveAuthorCommand(id));
      return Ok("Author Succesfully Deleted");
    }



  }
}

