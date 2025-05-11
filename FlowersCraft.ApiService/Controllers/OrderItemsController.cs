using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersCraft.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemService _service;

    public OrderItemsController(IOrderItemService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<OrderItemDto>), StatusCodes.Status200OK)]
    [EndpointSummary("Получить все элементы заказов")]
    [EndpointDescription("Возвращает список всех элементов заказов в системе")]
    public async Task<ActionResult<List<OrderItemDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Получить элемент заказа по ID")]
    [EndpointDescription("Возвращает один элемент заказа по заданному идентификатору")]
    public async Task<ActionResult<OrderItemDto>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status201Created)]
    [EndpointSummary("Создать новый элемент заказа")]
    [EndpointDescription("Добавляет новый элемент заказа в систему и возвращает его с присвоенным ID")]
    public async Task<ActionResult<OrderItemDto>> Create(OrderItemDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Обновить существующий элемент заказа")]
    [EndpointDescription("Обновляет данные элемента заказа по его идентификатору")]
    public async Task<IActionResult> Update(int id, OrderItemDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Удалить элемент заказа по ID")]
    [EndpointDescription("Удаляет элемент заказа с указанным идентификатором")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}

