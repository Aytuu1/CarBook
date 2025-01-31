

using CarBook.Application.Interfaces.TagCloudInfterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.TagCloudRepositories
{
  public class TagCloudRepository : ITagCloudRepository
  {
    private readonly CarBookContext _context;

    public TagCloudRepository(CarBookContext context)
    {
      _context = context;
    }

    public async Task<List<TagCloud>> GetTagCloudsByBlogId(int id)
    {
      var values = await _context.TagClouds.Where(x => x.BlogID == id).AsNoTracking().ToListAsync();
      return values;
    }






  }
}
