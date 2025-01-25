using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand>
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> entities)
        {
            _repository = entities;
        }

    public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
      await _repository.CreateAsync(new Category
      {
        Name = command.Name,

      });
    }
  }
}
