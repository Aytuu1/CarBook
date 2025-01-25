using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BrandHandlers
{
  public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommands>
  {
    private readonly IRepository<Brand> _repository;

    public RemoveBrandCommandHandler(IRepository<Brand> repository)
    {
      _repository = repository;
    }

    public async Task Handle(RemoveBrandCommands command, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(command.Id);
      await _repository.RemoveAsync(value);
    }







  }
}
