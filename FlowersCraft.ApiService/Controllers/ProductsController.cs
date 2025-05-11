using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersCraft.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
    [EndpointSummary("Получить список всех товаров")]
    [EndpointDescription("Возвращает список всех товаров, включая категории и связанные данные")]
    public async Task<ActionResult<List<ProductDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Получить товар по идентификатору")]
    [EndpointDescription("Возвращает конкретный товар с категорией по заданному ID")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
    [EndpointSummary("Создать новый товар")]
    [EndpointDescription("Создаёт новый товар в базе данных и возвращает его с присвоенным ID")]
    public async Task<ActionResult<ProductDto>> Create(ProductDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Обновить существующий товар")]
    [EndpointDescription("Обновляет данные товара на основе переданного ID и DTO")]
    public async Task<IActionResult> Update(int id, ProductDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Удалить товар")]
    [EndpointDescription("Удаляет товар по указанному идентификатору")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}


