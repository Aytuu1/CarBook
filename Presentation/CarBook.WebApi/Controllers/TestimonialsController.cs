using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestimonialsController : ControllerBase
  {
    private readonly IMediator _mediator;

    public TestimonialsController(IMediator mediator)
    {
      _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> TestimonialList()
    {
      var testimonialList = await _mediator.Send(new GetTestimonialQuery());
      return Ok(testimonialList);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> getTestimonial([FromRoute] int id)
    {
      var getTestimonial = await _mediator.Send(new GetTestimonialByIdQuery(id));
      return Ok(getTestimonial);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommand command)
    {
      await _mediator.Send(command);
      return Ok("Testimonial information updated succesfully");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTestimonial([FromRoute] int id)
    {
      await _mediator.Send(new RemoveTestimonialCommand(id));
      return Ok("Testimonial information deleted succesfully");
    }











  }
}
