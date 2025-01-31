using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Blogs")]
  [ApiController]
  public class BlogsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> BlogList()
    {
      var blogToList = await _mediator.Send(new GetBlogQuery());
      return Ok(blogToList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog([FromRoute] int id)
    {
      var getToBlog = await _mediator.Send(new GetBlogByIdQuery(id));
      return Ok(getToBlog);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand command)
    {
      await _mediator.Send(command);
      return Ok("Updated Succesfully Blog");
    }
    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
    {
      await _mediator.Send(command);
      return Ok("Created Succesfully Blog");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBlog([FromRoute] int id)
    {
      await _mediator.Send(new RemoveBlogCommand(id));
      return Ok("Deleted Succesfully Blog");
    }
    [HttpGet("GetLast3BlogWithAuthorsList")]
    public async Task<IActionResult> GetLast3BlogWithAuthorsList()
    {
      var getLast3Blog = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
      return Ok(getLast3Blog);
    }

    [HttpGet("GetAllBlogWithAuthors")]
    public async Task<IActionResult> GetAllBlogWithAuthors()
    {
      var getAllBlogWithAuthors = await _mediator.Send(new GetAllBlogWithAuthorQuery());
      return Ok(getAllBlogWithAuthors);
    }

    [HttpGet("GetBlogByAuthorId/{id}")]
    public async Task<IActionResult> GetBlogByAuthorId([FromRoute] int id)
    {
      var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
      return Ok(values);
    }


















  }
}
