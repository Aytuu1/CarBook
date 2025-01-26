

using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
  public class RemoveTestimonialCommand : IRequest
  {
    public RemoveTestimonialCommand(int ıd)
    {
      Id = ıd;
    }

    public int Id { get; set; }
  }

}
