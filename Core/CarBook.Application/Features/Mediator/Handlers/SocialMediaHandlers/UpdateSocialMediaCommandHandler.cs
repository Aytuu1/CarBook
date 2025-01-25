
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
  public class UpdateSocialMediaCommandHandler:IRequestHandler<UpdateSocialMediaCommand>
  {
    private readonly IRepository<SocialMedia> _repository;

    public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
    {
      var updateSocialMedia = await _repository.GetByIdAsync(request.SocialMediaID);
      updateSocialMedia.Icon = request.Icon;
      updateSocialMedia.Name = request.Name;
      updateSocialMedia.Url = request.Url;
      await _repository.UpdateAsync(updateSocialMedia);
    }
  }
}
