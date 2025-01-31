

using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
  public interface IBlogRepository
  {
    public Task<List<Blog>> GetLast3BlogsWithAuthors();
    public List<Blog> GetAllBlogWithAuthors();
    public List<Blog> GetBlogByAuthorId(int id);







  }
}
