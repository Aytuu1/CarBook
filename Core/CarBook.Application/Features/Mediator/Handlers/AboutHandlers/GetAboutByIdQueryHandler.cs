﻿using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
  public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
  {
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler(IRepository<About> repository)
    {
      _repository = repository;
    }
    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(query.Id);
      return new GetAboutByIdQueryResult
      {
        AboutID = values.AboutID,
        Description = values.Description,
        ImageUrl = values.ImageUrl,
        Title = values.Title,
      };
    }
  }
}
