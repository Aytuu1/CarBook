using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.FooterAddressViewComponents
{
  public class _FooterAddressViewComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _httpClientFactory;
    public _FooterAddressViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/FooterAddresses");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var footerAddressesList = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
        return View(footerAddressesList);
      }
      return View();
    }
  }
}
