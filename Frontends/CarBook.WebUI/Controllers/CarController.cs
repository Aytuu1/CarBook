﻿using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
  public class CarController : Controller
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public CarController(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
      ViewBag.v1 = "Araçlarımız";
      ViewBag.v2 = "Aracınızı Seçiniz";
      var client = _httpClientFactory.CreateClient();
      var responseMessage = await client.GetAsync("https://localhost:7203/api/Cars/GetCarsWithPricing");
      if (responseMessage.IsSuccessStatusCode)
      {
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var getCarwithBrandList = JsonConvert.DeserializeObject<List<ResultCarsWithPricingDto>>(jsonData);
        return View(getCarwithBrandList);
      }
      return View();
    }









  }
}
