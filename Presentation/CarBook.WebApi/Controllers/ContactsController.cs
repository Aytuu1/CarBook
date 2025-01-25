
using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
   private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
      var result = await _mediator.Send(new GetContactQuery());
      return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact([FromRoute] int id)
    {
      var result = await _mediator.Send(new GetContactByIdQuery(id));
      return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand command)
    {
      await _mediator.Send(command);
      return Ok("Contact information added");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
    {
      await _mediator.Send(command);
      return Ok("Contact information updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveContact([FromRoute] int id)
    {
      await _mediator.Send(new RemoveContactCommand(id));
      return Ok("Contact information removed");
    }







  }
}
