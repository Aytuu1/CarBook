

using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
  public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
  {
    private readonly IRepository<Blog> _repository;

    public UpdateBlogCommandHandler(IRepository<Blog> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
      var updatedToBlog = await _repository.GetByIdAsync(request.BlogID);
      updatedToBlog.Title = request.Title;
      updatedToBlog.CreatedDate = request.CreatedDate;
      updatedToBlog.CategoryID = request.CategoryID;
      updatedToBlog.AuthorID = request.AuthorID;
      updatedToBlog.CoverImageUrl = request.CoverImageUrl;
      await _repository.UpdateAsync(updatedToBlog);

    }
  }
}
