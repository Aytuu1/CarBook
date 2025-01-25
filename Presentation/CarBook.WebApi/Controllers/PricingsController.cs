using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PricingsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public PricingsController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> PricingList()
    {
      var pricingList = await _mediator.Send(new GetPricingQuery());
      return Ok(pricingList);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPricing([FromRoute] int id)
    {
      var getPricing = await _mediator.Send(new GetPricingByIdQuery(id));
      return Ok(getPricing);
    }
    [HttpPost]
    public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommand command)
    {
      await _mediator.Send(command);
      return Ok("Pricing created successfully");
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePricing([FromBody]UpdatePricingCommand command)
    {
      await _mediator.Send(command);
      return Ok("Pricing updated successfully");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePricing([FromRoute] int id)
    {
      await _mediator.Send(new RemovePricingCommand(id));
      return Ok("Pricing deleted successfully");
    }








  }
}
