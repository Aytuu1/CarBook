using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.Mediator.Commands.CategoryCommands;
using CarBook.Application.Features.Mediator.Handlers.CategoryHandlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

    public CategoryController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
    {
      _getCategoryQueryHandler = getCategoryQueryHandler;
      _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
      _createCategoryCommandHandler = createCategoryCommandHandler;
      _updateCategoryCommandHandler = updateCategoryCommandHandler;
      _removeCategoryCommandHandler = removeCategoryCommandHandler;
    }



    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
      var values = await _getCategoryQueryHandler.Handle();
      return Ok(values);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
      var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
      return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
      await _createCategoryCommandHandler.Handle(command);
      return Ok("Kategori Eklendi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
      await _updateCategoryCommandHandler.Handle(command);
      return Ok("Kategori güncellendi");
    }
    [HttpDelete]
    public async Task<IActionResult> RemoveCategory(int id)
    {
      await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
      return Ok("Kategori Silindi");
    }

  }
}
