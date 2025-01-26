

using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
  public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
  {
    private readonly IRepository<Testimonial> _repository;

    public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
      var updatedValue = await _repository.GetByIdAsync(request.TestimonialID);
      updatedValue.Title = request.Title;
      updatedValue.Comment = request.Comment;
      updatedValue.Name = request.Name;
      updatedValue.ImageUrl = request.ImageUrl;
      await _repository.UpdateAsync(updatedValue);
    }
  }
}
