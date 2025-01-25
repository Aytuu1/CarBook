using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Features.Mediator.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly CreateContactCommandHandler _createContactCommand;
    private readonly UpdateContactCommandHandler _updateContactCommand;
    private readonly RemoveContactCommandHandler _removeContactCommand;
    private readonly GetContactByIdQueryHandler _getContactByIdQuery;
    private readonly GetContactQueryHandler _getContactQuery;

    public ContactsController(CreateContactCommandHandler createContactCommand, UpdateContactCommandHandler updateContactCommand, RemoveContactCommandHandler removeContactCommand, GetContactByIdQueryHandler getContactByIdQuery, GetContactQueryHandler getContactQuery)
    {
      _createContactCommand = createContactCommand;
      _updateContactCommand = updateContactCommand;
      _removeContactCommand = removeContactCommand;
      _getContactByIdQuery = getContactByIdQuery;
      _getContactQuery = getContactQuery;
    }

    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
      var result = await _getContactQuery.Handle();
      return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact([FromRoute] int id)
    {
      var result = await _getContactByIdQuery.Handle(new GetContactByIdQuery(id));
      return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactCommand command)
    {
      await _createContactCommand.Handle(command);
      return Ok("Contact information added");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
    {
      await _updateContactCommand.Handle(command);
      return Ok("Contact information updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveContact([FromRoute] int id)
    {
      await _removeContactCommand.Handle(new RemoveContactCommand(id));
      return Ok("Contact information removed");
    }







  }
}
