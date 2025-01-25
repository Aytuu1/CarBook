using CarBook.Application.Features.Mediator.Results.CategoryResults;
using MediatR;


namespace CarBook.Application.Features.Mediator.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery:IRequest<GetCategoryByIdQueryResult>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
