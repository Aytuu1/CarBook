using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BrandHandlers
{
  public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommands>
  {
    private readonly IRepository<Brand> _repository;

    public CreateBrandCommandHandler(IRepository<Brand> repository)
    {
      _repository = repository;
    }



    public async Task Handle(CreateBrandCommands command, CancellationToken cancellationToken)
    {
      await _repository.CreateAsync(new Brand
      {
        Name = command.Name,
      });
    }
  }
}
