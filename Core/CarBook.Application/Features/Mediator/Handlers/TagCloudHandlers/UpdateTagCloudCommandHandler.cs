
using CarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
  public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
  {
    private readonly IRepository<TagCloud> _repository;

    public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
    {
      var getUptadedTagCloud = await _repository.GetByIdAsync(request.TagCloudID);
      getUptadedTagCloud.Title = request.Title;
      getUptadedTagCloud.BlogID = request.BlogID;
      await _repository.UpdateAsync(getUptadedTagCloud);
    }
  }
}
