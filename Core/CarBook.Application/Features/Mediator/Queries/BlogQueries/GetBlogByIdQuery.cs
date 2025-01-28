﻿

using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
  public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
  {
    public GetBlogByIdQuery(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
  }
}
