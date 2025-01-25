using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
  public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
  {
    private readonly IRepository<Car> _repository;

    public CreateCarCommandHandler(IRepository<Car> repository)
    {
      _repository = repository;
    }

    public async Task Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
      await _repository.CreateAsync(new Car
      {
        BigImageUrl = command.BigImageUrl,
        Luggage = command.Luggage,
        Km = command.Km,
        Model = command.Model,
        Seat = command.Seat,
        Transmission = command.Transmission,
        CoverImageUrl = command.CoverImageUrl,
        BrandID = command.BrandID,
        Fuel = command.Fuel


      });
    }
  }
}
