using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
  public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
  {
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler(IRepository<Banner> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateBannerCommand command, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(command.BannerID);
      values.VideoDescription = command.VideoDescription;
      values.Description = command.Description;
      values.VideoUrl = command.VideoUrl;
      values.Title = command.Title;
      await _repository.UpdateAsync(values);
    }
  }
}
