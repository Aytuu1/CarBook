using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
  public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommands>
  {
    private readonly IRepository<Banner> _repository;

    public CreateBannerCommandHandler(IRepository<Banner> repository)
    {
      _repository = repository;
    }
    public async Task Handle(CreateBannerCommands command, CancellationToken cancellationToken)
    {
      await _repository.CreateAsync(new Banner
      {
        Description = command.Description,
        Title = command.Title,
        VideoDescription = command.VideoDescription,
        VideoUrl = command.VideoUrl,
      });
    }
  }
}
