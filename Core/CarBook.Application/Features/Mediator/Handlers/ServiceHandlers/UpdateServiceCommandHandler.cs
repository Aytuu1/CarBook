

using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
  public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
  {
    private readonly IRepository<Service> _repository;

    public UpdateServiceCommandHandler(IRepository<Service> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
      var updatedService = await _repository.GetByIdAsync(request.ServiceID);
      updatedService.Title = request.Title;
      updatedService.Description = request.Description;
      updatedService.IconUrl = request.IconUrl;
      await _repository.UpdateAsync(updatedService);

    }
  }
}
