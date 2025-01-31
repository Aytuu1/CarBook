using CarBook.Dto.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
  public class _BlogDetailsCategoryComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailsCategoryComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Category");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var getCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        return View(getCategory);
      }
      return View();
    }
  }
}
