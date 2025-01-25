﻿using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Features.Mediator.Handlers.AboutHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class AboutsController : ControllerBase
  {
    private readonly CreateAboutCommandHandler _createCommandHandler;
    private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
    private readonly GetAboutQueryHandler _getAboutQueryHandler;
    private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
    private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;

    public AboutsController(CreateAboutCommandHandler createCommandHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler, GetAboutQueryHandler getAboutQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler removeAboutCommandHandler)
    {
      _createCommandHandler = createCommandHandler;
      _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
      _getAboutQueryHandler = getAboutQueryHandler;
      _updateAboutCommandHandler = updateAboutCommandHandler;
      _removeAboutCommandHandler = removeAboutCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
      var values = await _getAboutQueryHandler.Handle();
      return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAbout(int id)
    {
      var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
      return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
    {
      await _createCommandHandler.Handle(command);
      return Ok("Hakkımda bilgisi eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveAbout(int id)
    {
      await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
      return Ok("Hakkımda bilgisi başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
    {
      await _updateAboutCommandHandler.Handler(command);
      return Ok("Hakkımda bilgisi güncellendi");
    }










  }
}
