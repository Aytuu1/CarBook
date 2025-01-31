using CarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInfterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
  public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
  {
    private readonly ITagCloudRepository _repository;

    public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
    {
      var getTagCloudByBlogId = await _repository.GetTagCloudsByBlogId(request.Id);
      return getTagCloudByBlogId.Select(x => new GetTagCloudByBlogIdQueryResult
      {
        BlogID = x.BlogID,
        TagCloudID = x.TagCloudID,
        Title = x.Title,
      }).ToList();


    }
  }
}
