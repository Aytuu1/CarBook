using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BrandHandlers
{
  public class UpdateBrandCommandHandlers : IRequestHandler<UpdateBrandCommands>
  {
    private readonly IRepository<Brand> _repository;

    public UpdateBrandCommandHandlers(IRepository<Brand> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateBrandCommands command, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(command.BrandID);
      value.Name = command.Name;
      await _repository.UpdateAsync(value);
    }










  }
}
