using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CategoryHandlers
{
  public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
  {
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(command.CategoryID);
      values.CategoryID = command.CategoryID;
      values.Name = command.Name;
      await _repository.UpdateAsync(values);
    }
  }
}
