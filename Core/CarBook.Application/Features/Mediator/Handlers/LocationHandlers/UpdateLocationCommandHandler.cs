﻿using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
  public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
  {
    private readonly IRepository<Location> _repository;

    public UpdateLocationCommandHandler(IRepository<Location> repository)
    {
      _repository = repository;
    }

    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(request.LocationID);
      value.Name = request.Name;
      await _repository.UpdateAsync(value);
    }











  }
}
