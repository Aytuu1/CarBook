using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
  public class BlogController : Controller
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public BlogController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Blogs/GetAllBlogWithAuthors");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var getAllBlogWithAuthors = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorsDto>>(jsonData);
        return View(getAllBlogWithAuthors);
      }
      return View();
    }
    public async Task<IActionResult> BlogDetail(int id)
    {
      ViewBag.v1 = "Bloglar";
      ViewBag.v2 = "Blog Detayı ve Yorumlar";
      ViewBag.blogid = id;
      return View();
    }
  }
}
