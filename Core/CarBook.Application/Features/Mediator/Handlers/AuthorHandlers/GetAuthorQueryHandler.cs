

using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
  public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
  {
    private readonly IRepository<Author> _repository;

    public GetAuthorQueryHandler(IRepository<Author> repository)
    {
      _repository = repository;
    }

    public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
     var authorList= await _repository.GetAllAsync();
      return authorList.Select(x => new GetAuthorQueryResult
      {
        Description = x.Description,
        ImageUrl = x.ImageUrl,
        Name = x.Name,
        AuthorID = x.AuthorID,
      }).ToList();
    }
  }
}
