﻿

using CarBook.Application.Features.Mediator.Results.BannerResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerByIdQuery: IRequest<GetBannerIdQueryResult>
  {
        public GetBannerByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }






}
