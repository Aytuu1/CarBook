﻿using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ContactHandlers
{
  public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
  {
    private readonly IRepository<Contact> _repository;

    public CreateContactCommandHandler(IRepository<Contact> contactRepository)
    {
      _repository = contactRepository;
    }
    public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
      await _repository.CreateAsync(new Contact
      {
        Email = request.Email,
        Message = request.Message,
        Name = request.Name,
        SendDate = request.SendDate,
        Subject = request.Subject,

      });
    }
  }
}
