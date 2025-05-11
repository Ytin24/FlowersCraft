using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersCraft.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatMessagesController : ControllerBase
{
    private readonly IChatMessageService _service;

    public ChatMessagesController(IChatMessageService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ChatMessageDto>), StatusCodes.Status200OK)]
    [EndpointSummary("Получить список сообщений")]
    [EndpointDescription("Возвращает список всех сообщений пользователя")]
    public async Task<ActionResult<List<ChatMessageDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ChatMessageDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Получить сообщение по ID")]
    [EndpointDescription("Возвращает конкретное сообщение")]
    public async Task<ActionResult<ChatMessageDto>> GetById(int id)
    {
        var msg = await _service.GetByIdAsync(id);
        return msg == null ? NotFound() : Ok(msg);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ChatMessageDto), StatusCodes.Status201Created)]
    [EndpointSummary("Создать новое сообщение")]
    [EndpointDescription("Создаёт новое сообщение и возвращает его с присвоенным ID")]
    public async Task<ActionResult<ChatMessageDto>> Create(ChatMessageDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Обновить сообщение")]
    [EndpointDescription("Обновляет текст сообщения и другие поля по ID")]
    public async Task<IActionResult> Update(int id, ChatMessageDto dto)
    {
        var success = await _service.UpdateAsync(id, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Удалить сообщение")]
    [EndpointDescription("Удаляет сообщение по его идентификатору")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}

