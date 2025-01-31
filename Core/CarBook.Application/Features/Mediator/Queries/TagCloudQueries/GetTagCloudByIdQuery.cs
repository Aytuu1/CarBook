using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
  public class GetTagCloudByIdQuery:IRequest<GetTagCloudByIdQueryResult>
  {
    public GetTagCloudByIdQuery(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
    }
}
