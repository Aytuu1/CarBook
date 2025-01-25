


using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
  public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAdressByIdQueryResult>
  {
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
    {
      _repository = repository;
    }

    public async Task<GetFooterAdressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
      var value = await _repository.GetByIdAsync(request.Id);
      return new GetFooterAdressByIdQueryResult
      {
        Address = value.Address,
        Description = value.Description,
        Email = value.Email,
        FooterAddressID = value.FooterAddressID,
        Phone = value.Phone
      };
    }
  }
}
