
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
  public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
  {
    private readonly IRepository<FooterAddress> _repository;

    public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
    {
      _repository = repository;
    }

    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
      var value = await _repository.GetAllAsync();
      return value.Select(x => new GetFooterAddressQueryResult
      {
        Address = x.Address,
        Email = x.Email,
        Description = x.Description,
        Phone = x.Phone,
        FooterAddressID = x.FooterAddressID
        
      }).ToList();
    }
  }
}
