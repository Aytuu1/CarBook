using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
  public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
  {
    private readonly IRepository<About> _repository;

    public RemoveAboutCommandHandler(IRepository<About> repository)
    {
      _repository = repository;
    }
    public async Task Handle(RemoveAboutCommand command, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(command.Id);
      await _repository.RemoveAsync(value);
    }
  }
}
