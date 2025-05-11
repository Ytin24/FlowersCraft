using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersCraft.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderStatusesController : ControllerBase
{
    private readonly IOrderStatusService _service;

    public OrderStatusesController(IOrderStatusService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<OrderStatusDto>), StatusCodes.Status200OK)]
    [EndpointSummary("Получить все статусы заказов")]
    [EndpointDescription("Возвращает список всех статусов, использующихся для заказов")]
    public async Task<ActionResult<List<OrderStatusDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{code}")]
    [ProducesResponseType(typeof(OrderStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Получить статус по коду")]
    [EndpointDescription("Возвращает статус заказа по строковому коду")]
    public async Task<ActionResult<OrderStatusDto>> GetByCode(string code)
    {
        var status = await _service.GetByCodeAsync(code);
        return status == null ? NotFound() : Ok(status);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderStatusDto), StatusCodes.Status201Created)]
    [EndpointSummary("Создать статус")]
    [EndpointDescription("Создаёт новый статус заказа")]
    public async Task<ActionResult<OrderStatusDto>> Create(OrderStatusDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByCode), new { code = created.Code }, created);
    }

    [HttpPut("{code}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Обновить статус")]
    [EndpointDescription("Обновляет наименование статуса заказа по коду")]
    public async Task<IActionResult> Update(string code, OrderStatusDto dto)
    {
        var success = await _service.UpdateAsync(code, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{code}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Удалить статус")]
    [EndpointDescription("Удаляет статус заказа по коду")]
    public async Task<IActionResult> Delete(string code)
    {
        var success = await _service.DeleteAsync(code);
        return success ? NoContent() : NotFound();
    }
}
