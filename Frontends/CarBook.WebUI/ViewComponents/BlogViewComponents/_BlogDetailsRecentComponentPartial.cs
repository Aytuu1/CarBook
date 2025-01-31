using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
  public class _BlogDetailsRecentComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailsRecentComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Blogs/GetLast3BlogWithAuthorsList");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var getLast3Blog = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthorsDto>>(jsonData);
        return View(getLast3Blog);
      }
      return View();
    }
  }
}
