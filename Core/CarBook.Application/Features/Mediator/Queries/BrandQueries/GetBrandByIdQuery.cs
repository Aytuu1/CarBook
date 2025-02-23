﻿using CarBook.Application.Features.Mediator.Results.BrandResults;
using MediatR;


namespace CarBook.Application.Features.Mediator.Queries.BrandQueries
{
    public class GetBrandByIdQuery:IRequest<GetBrandByIdQueryResult>
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
