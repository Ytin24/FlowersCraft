using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersCraft.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
    [EndpointSummary("Получить список всех заказов")]
    [EndpointDescription("Возвращает список заказов с привязанными товарами")]
    public async Task<ActionResult<List<OrderDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Получить заказ по ID")]
    [EndpointDescription("Возвращает заказ по идентификатору со всеми позициями заказа")]
    public async Task<ActionResult<OrderDto>> GetById(int id)
    {
        var order = await _service.GetByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
    [EndpointSummary("Создать новый заказ")]
    [EndpointDescription("Создаёт заказ и возвращает его с присвоенным ID")]
    public async Task<ActionResult<OrderDto>> Create(OrderDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Обновить заказ")]
    [EndpointDescription("Обновляет данные заказа по идентификатору")]
    public async Task<IActionResult> Update(int id, OrderDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Удалить заказ")]
    [EndpointDescription("Удаляет заказ по указанному идентификатору")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}

