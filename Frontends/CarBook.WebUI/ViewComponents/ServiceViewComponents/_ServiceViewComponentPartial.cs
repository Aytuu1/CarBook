﻿using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.ServiceViewComponents
{
  public class _ServiceViewComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _httpClientFactory;
    public _ServiceViewComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Services");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var readedServiceValue = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
        return View(readedServiceValue);
      }
      return View();
    }
  }
}
