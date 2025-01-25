

using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAdressQueries
{
  public class GetFooterAddressByIdQuery : IRequest<GetFooterAdressByIdQueryResult>
  {
    public GetFooterAddressByIdQuery(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
  }
}
