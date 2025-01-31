using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.TagCloudInfterfaces
{
  public interface ITagCloudRepository
  {
    Task<List<TagCloud>> GetTagCloudsByBlogId(int id);
  }
}
