using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.CarResults
{
  public class GetCarsWithPricingQueryResult
  {
    public int CarPricingID { get; set; }
    public string BrandName { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public string PricingName { get; set; }
    public decimal PricingAmount { get; set; }
  }
}
