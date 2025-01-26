

using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{

  public class GetLast5CarsWithBrandQueryHandler : IRequestHandler<GetLast5CarsWithBrandQuery, List<GetLast5CarsWithBrandQueryResult>>
  {
    private readonly ICarRepository _carRepository;

    public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
    {
      _carRepository = carRepository;
    }



    public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
    {
      var value = await _carRepository.GetLast5CarsWithBrands();
      return value.Select(x => new GetLast5CarsWithBrandQueryResult
      {
        BigImageUrl = x.BigImageUrl,
        BrandID = x.BrandID,
        CarID = x.CarID,
        CoverImageUrl = x.CoverImageUrl,
        Fuel = x.Fuel,
        Km = x.Km,
        Luggage = x.Luggage,
        Model = x.Model,
        Seat = x.Seat,
        Transmission = x.Transmission,
        BrandName = x.Brand.Name

      }).ToList();
    }


  }
}
