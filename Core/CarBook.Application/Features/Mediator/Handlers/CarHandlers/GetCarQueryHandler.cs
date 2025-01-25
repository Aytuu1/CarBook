using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
  public class GetCarQueryHandler : IRequestHandler<GetCarQuery, List<GetCarQueryResult>>
  {
    private readonly IRepository<Car> _repository;

    public GetCarQueryHandler(IRepository<Car> repository)
    {
      _repository = repository;
    }


    public async Task<List<GetCarQueryResult>> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
      var values = await _repository.GetAllAsync();
      return values.Select(x => new GetCarQueryResult
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
        Transmission = x.Transmission


      }).ToList();
    }
  }
}
