using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler:IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
  {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

       
    public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(request.Id);
      return new GetCarByIdQueryResult
      {
        BigImageUrl = value.BigImageUrl,
        BrandID = value.BrandID,
        CarID = value.CarID,
        CoverImageUrl = value.CoverImageUrl,
        Fuel = value.Fuel,
        Km = value.Km,
        Luggage = value.Luggage,
        Model = value.Model,
        Seat = value.Seat,
        Transmission = value.Transmission

      };
    }
  }
}
