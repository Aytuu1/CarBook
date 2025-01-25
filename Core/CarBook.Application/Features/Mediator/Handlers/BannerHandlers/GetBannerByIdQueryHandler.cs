using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
  public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, GetBannerIdQueryResult>
  {
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandler(IRepository<Banner> repository)
    {
      _repository = repository;
    }


    public async Task<GetBannerIdQueryResult> Handle(GetBannerByIdQuery query, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(query.Id);
      return new GetBannerIdQueryResult
      {
        BannerID = values.BannerID,
        Description = values.Description,
        Title = values.Title,
        VideoUrl = values.VideoUrl,
        VideoDescription = values.VideoDescription
      };
    }
  }
}
