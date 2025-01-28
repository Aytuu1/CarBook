
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
  public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
  {
    private readonly IRepository<Author> _repository;

    public UpdateAuthorCommandHandler(IRepository<Author> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
      var updatedAuthor = await _repository.GetByIdAsync(request.AuthorID);
      updatedAuthor.Description = request.Description;
      updatedAuthor.Name = request.Name;
      updatedAuthor.ImageUrl = request.ImageUrl;
      await _repository.UpdateAsync(updatedAuthor);
    }
  }
}
