﻿using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ContactHandlers
{

    public class GetContactByIdQueryHandler:IRequestHandler<GetContactByIdQuery,GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

    public GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
      _repository = repository;
    }

    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(request.Id);
      return new GetContactByIdQueryResult
      {
        ContactID = values.ContactID,
        Name = values.Name,
        Email = values.Email,
        Message = values.Message,
        SendDate = values.SendDate,
        Subject = values.Subject


      };
    }
  }
}


