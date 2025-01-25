using CarBook.Application.Features.Mediator.Results.ContactResults;
using MediatR;


namespace CarBook.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetContactByIdQuery:IRequest<GetContactByIdQueryResult>
    {
        public GetContactByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
