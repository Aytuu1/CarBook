using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Handlers.CarHandlers;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/Cars")]
  [ApiController]
  public class CarsController : ControllerBase
  {

    private readonly IMediator _mediator;
    private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

    public CarsController(IMediator mediator, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
    {
      _mediator = mediator;
      _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;

    }

    [HttpGet]
    public async Task<IActionResult> CarList()
    {
      var values = await _mediator.Send(new GetCarQuery());
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCar([FromRoute]int id)
    {
      var values = await _mediator.Send(new GetCarByIdQuery(id));
      return Ok(values);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCar([FromRoute] int id)
    {
      await _mediator.Send(new RemoveCarCommand(id));
      return Ok("Deleted information Car");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCar([FromBody]UpdateCarCommand command)
    {
      await _mediator.Send(command);
      return Ok("Araba bilgisi güncellendi");
    }
    [HttpPost]
    public async Task<IActionResult> CreateCar([FromBody]CreateCarCommand command)
    {
      await _mediator.Send(command);
      return Ok("Deleted information Car");
    }

    [HttpGet("GetCarWithBrand")]
    public IActionResult GetCarWithBrand()
    {
      var values = _getCarWithBrandQueryHandler.Handle();
      return Ok(values);
    }
    [HttpGet("GetLast5CarsWithBrand")]

    public async Task<IActionResult> GetLast5Cars()
    {
      var value = await _mediator.Send(new GetLast5CarsWithBrandQuery());
      return Ok(value);
    }







  }
}
