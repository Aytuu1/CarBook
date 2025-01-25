using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
  public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
  {
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandler(IRepository<Car> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(command.CarID);
      value.Transmission = command.Transmission;
      value.Luggage = command.Luggage;
      value.Fuel = command.Fuel;
      value.Km = command.Km;
      value.BrandID = command.BrandID;
      value.BigImageUrl = command.BigImageUrl;
      value.CoverImageUrl = command.CoverImageUrl;
      value.Model = command.Model;
      value.Seat = command.Seat;
      await _repository.UpdateAsync(value);
    }
  }
}
