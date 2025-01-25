using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
  public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
  {
    public GetPricingByIdQuery(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
  }
}
