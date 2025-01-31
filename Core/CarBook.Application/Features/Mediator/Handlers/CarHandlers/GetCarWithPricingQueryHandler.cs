using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
  public class GetCarWithPricingQueryHandler : IRequestHandler<GetCarWithPricingQuery, List<GetCarsWithPricingQueryResult>>
  {
    private readonly ICarRepository _repository;

    public GetCarWithPricingQueryHandler(ICarRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<GetCarsWithPricingQueryResult>> Handle(GetCarWithPricingQuery request, CancellationToken cancellationToken)
    {
      var getCarWithPricing = await _repository.GetCarsWithPricings();
      return getCarWithPricing.Select(x => new GetCarsWithPricingQueryResult
      {
        Model = x.Car.Model,
        CoverImageUrl = x.Car.CoverImageUrl,
        BrandName = x.Car.Brand.Name,
        PricingName = x.Pricing.Name,
        PricingAmount = x.Amount,
        CarPricingID = x.CarPricingID

      }).ToList();
    }
  }
}
