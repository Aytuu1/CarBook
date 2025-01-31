using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
  public class GetAllBlogWithAuthorQueryHandler : IRequestHandler<GetAllBlogWithAuthorQuery, List<GetAllBlogWithAuthorQueryResult>>
  {
    private readonly IBlogRepository _repository;

    public GetAllBlogWithAuthorQueryHandler(IBlogRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogWithAuthorQuery request, CancellationToken cancellationToken)
    {
      var getAllBlogWithAuthors = _repository.GetAllBlogWithAuthors();
      return getAllBlogWithAuthors.Select(x => new GetAllBlogWithAuthorQueryResult
      {
        AuthorName = x.Author.Name,
        CoverImageUrl = x.CoverImageUrl,
        Title = x.Title,
        BlogID = x.BlogID,
        CategoryID = x.CategoryID,
        AuthorID = x.AuthorID,
        CreatedDate = x.CreatedDate,
        Description = x.Description,
        AuthorDescripton=x.Author.Description,
        AuthorImageUrl=x.Author.ImageUrl

      }).ToList();
    }
  }
}
