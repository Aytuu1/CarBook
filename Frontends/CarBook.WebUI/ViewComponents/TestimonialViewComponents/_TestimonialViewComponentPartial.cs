using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TestimonialViewComponents
{

  public class _TestimonialViewComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public _TestimonialViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Testimonials");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var readedValue = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
        return View(readedValue);
      }
      return View();
    }




  }
}
