using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
  public class _GetLast3BlogsWithAuthorsComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _clientFactory;

    public _GetLast3BlogsWithAuthorsComponentPartial(IHttpClientFactory clientFactory)
    {
      _clientFactory = clientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = _clientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Blogs/GetLast3BlogWithAuthorsList");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var readedData = JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthorsDto>>(jsonData);
        return View(readedData);

      }
      return View();
    }







  }
}
