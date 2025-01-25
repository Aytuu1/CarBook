using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CategoryHandlers
{
  public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
  {
    private readonly IRepository<Category> _repository;

    public RemoveCategoryCommandHandler(IRepository<Category> repository)
    {
      _repository = repository;
    }

    public async Task Handle(RemoveCategoryCommand command, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(command.Id);
      await _repository.RemoveAsync(values);
    }
  }
}
