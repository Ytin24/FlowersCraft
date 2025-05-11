using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using FlowersCraft.ApiService.Abstractions;

namespace FlowersCraft.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoriesController(IProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductCategoryDto>), StatusCodes.Status200OK)]
        [EndpointSummary("Получить все категории")]
        [EndpointDescription("Возвращает все категории товаров, включая вложенные продукты")]
        public async Task<ActionResult<List<ProductCategoryDto>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EndpointSummary("Получить категорию по ID")]
        [EndpointDescription("Возвращает категорию товаров и её продукты по ID")]
        public async Task<ActionResult<ProductCategoryDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductCategoryDto), StatusCodes.Status201Created)]
        [EndpointSummary("Создать категорию")]
        [EndpointDescription("Создаёт новую категорию товаров")]
        public async Task<ActionResult<ProductCategoryDto>> Create(ProductCategoryDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EndpointSummary("Обновить категорию")]
        [EndpointDescription("Обновляет категорию по идентификатору")]
        public async Task<IActionResult> Update(int id, ProductCategoryDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EndpointSummary("Удалить категорию")]
        [EndpointDescription("Удаляет категорию по идентификатору")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
