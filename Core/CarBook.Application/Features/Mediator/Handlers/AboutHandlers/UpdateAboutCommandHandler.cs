using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
  public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
  {
    private readonly IRepository<About> _repository;

    public UpdateAboutCommandHandler(IRepository<About> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateAboutCommand command, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(command.AboutID);
      value.Title = command.Title;
      value.Description = command.Description;
      value.ImageUrl = command.ImageUrl;
      await _repository.UpdateAsync(value);
    }














  }
}
