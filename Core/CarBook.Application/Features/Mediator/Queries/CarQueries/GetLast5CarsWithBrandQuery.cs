﻿

using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
  public class GetLast5CarsWithBrandQuery : IRequest<List<GetLast5CarsWithBrandQueryResult>>
  {
  }
}
