﻿using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
  public class _BlogDetailsTagCloudComponentPartial : ViewComponent
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public _BlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync($"https://localhost:7203/api/TagClouds/getTagCloudByBlogId/{id}");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var getValue = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsonData);
        return View(getValue);
      }
      return View();
    }







  }
}
