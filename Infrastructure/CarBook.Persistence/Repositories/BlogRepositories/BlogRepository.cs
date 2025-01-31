

using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
  public class BlogRepository : IBlogRepository
  {
    private readonly CarBookContext _context;

    public BlogRepository(CarBookContext context)
    {
      _context = context;
    }

    public List<Blog> GetAllBlogWithAuthors()
    {
      var getAllBlogWithAuthors = _context.Blogs.Include(x => x.Author).AsNoTracking().ToList();
      return getAllBlogWithAuthors;
    }

    public List<Blog> GetBlogByAuthorId(int id)
    {
      var getBlogByAuthor = _context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).AsNoTracking().ToList();
      return getBlogByAuthor;
    }

    public async Task<List<Blog>> GetLast3BlogsWithAuthors()
    {
      var blog = await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).AsNoTracking().ToListAsync();
      return blog;
    }
  }
}
