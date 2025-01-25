using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Handlers.CarHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/Cars")]
  [ApiController]
  public class CarsController : ControllerBase
  {

    private readonly CreateCarCommandHandler _createCommandHandler;
    private readonly UpdateCarCommandHandler _updateCommandHandler;
    private readonly RemoveCarCommandHandler _removeCommandHandler;
    private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
    private readonly GetCarQueryHandler _getCarQueryHandler;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

    public CarsController(CreateCarCommandHandler createCommandHandler, UpdateCarCommandHandler updateCommandHandler, RemoveCarCommandHandler removeCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
    {
      _createCommandHandler = createCommandHandler;
      _updateCommandHandler = updateCommandHandler;
      _removeCommandHandler = removeCommandHandler;
      _getCarByIdQueryHandler = getCarByIdQueryHandler;
      _getCarQueryHandler = getCarQueryHandler;
      _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
      var values = await _getCarQueryHandler.Handle();
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar(int id)
    {
      var values = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
      return Ok(values);
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
      await _removeCommandHandler.Handle(new RemoveCarCommand(id));
      return Ok("Araba bilgisi silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
      await _updateCommandHandler.Handle(command);
      return Ok("Araba bilgisi güncellendi");
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
      await _createCommandHandler.Handle(command);
      return Ok("Araba Bilgisi Eklendi");
    }

    [HttpGet("car")]
    public IActionResult GetCarWithBrand()
    {
      var values = _getCarWithBrandQueryHandler.Handle();
      return Ok(values);
    }










  }
}
