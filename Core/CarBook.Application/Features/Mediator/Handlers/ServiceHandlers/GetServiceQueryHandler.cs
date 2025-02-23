﻿

using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
  public class GetServiceQueryHandler:IRequestHandler<GetServiceQuery,List<GetServiceQueryResult>>
  {
    private readonly IRepository<Service> _repository;

    public GetServiceQueryHandler(IRepository<Service> repository)
    {
      _repository = repository;
    }

    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
      var serviceList = await _repository.GetAllAsync();
      return serviceList.Select(x => new GetServiceQueryResult
      {
        ServiceID=x.ServiceID,
        Title = x.Title,
        Description = x.Description,
        IconUrl = x.IconUrl

      }).ToList();
    }








  }
}
