using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace CarBook.Persistence.Repositories.CarRepository
{
  public class CarRepository : ICarRepository
  {
    private readonly CarBookContext _context;

    public CarRepository(CarBookContext context)
    {
      _context = context;
    }

    public List<Car> GetCarsListWithBrands()
    {
      var values = _context.Cars.Include(x => x.Brand).AsNoTracking().ToList();
      return values;
    }

    public async Task<List<CarPricing>> GetCarsWithPricings()
    {
      var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(y => y.Pricing).Where(z=>z.PricingID==2).AsNoTracking().ToListAsync();
      return values;
    }

    public async Task<List<Car>> GetLast5CarsWithBrands()
    {
      var values = await _context.Cars.Include(x => x.Brand).AsNoTracking().OrderByDescending(x => x.CarID).Take(5).ToListAsync();
      return values;

    }
  }
}
