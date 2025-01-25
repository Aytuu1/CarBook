using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.Mediator.Commands.BrandCommands;
using CarBook.Application.Features.Mediator.Handlers.BrandHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class BrandsController : ControllerBase
  {
    private readonly CreateBrandCommandHandler _createCommandHandler;
    private readonly UpdateBrandCommandHandlers _updateCommandHandler;
    private readonly RemoveBrandCommandHandler _removeCommandHandler;
    private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
    private readonly GetBrandQueryHandler _getBrandQueryHandler;

    public BrandsController(CreateBrandCommandHandler createCommandHandler, UpdateBrandCommandHandlers updateCommandHandler, RemoveBrandCommandHandler removeCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getBrandQueryHandler)
    {
      _createCommandHandler = createCommandHandler;
      _updateCommandHandler = updateCommandHandler;
      _removeCommandHandler = removeCommandHandler;
      _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
      _getBrandQueryHandler = getBrandQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> BrandList()
    {
      var values = await _getBrandQueryHandler.Handle();
      return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrand(int id)
    {
      var values = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
      return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommands command)
    {
      await _createCommandHandler.Handle(command);
      return Ok("Marka bilgisi Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBrand(UpdateBrandCommands commands)
    {
      await _updateCommandHandler.Handler(commands);
      return Ok("Marka bilgisi güncellendi");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveBrand(int id)
    {
      await _removeCommandHandler.Handler(new RemoveBrandCommands(id));
      return Ok("Marka bilgileri silindi");
    }







  }
}
