using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlowersCraft.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatSendersController : ControllerBase
{
    private readonly IChatSenderService _service;

    public ChatSendersController(IChatSenderService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ChatSenderDto>), StatusCodes.Status200OK)]
    [EndpointSummary("Получить список всех отправителей чата")]
    [EndpointDescription("Возвращает всех зарегистрированных отправителей сообщений")]
    public async Task<ActionResult<List<ChatSenderDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{code}")]
    [ProducesResponseType(typeof(ChatSenderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Получить отправителя по коду")]
    [EndpointDescription("Возвращает отправителя по строковому коду")]
    public async Task<ActionResult<ChatSenderDto>> GetByCode(string code)
    {
        var item = await _service.GetByCodeAsync(code);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ChatSenderDto), StatusCodes.Status201Created)]
    [EndpointSummary("Создать нового отправителя")]
    [EndpointDescription("Создаёт нового отправителя сообщений с уникальным кодом")]
    public async Task<ActionResult<ChatSenderDto>> Create(ChatSenderDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetByCode), new { code = created.Code }, created);
    }

    [HttpPut("{code}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Обновить отправителя")]
    [EndpointDescription("Обновляет имя отправителя по его коду")]
    public async Task<IActionResult> Update(string code, ChatSenderDto dto)
    {
        var success = await _service.UpdateAsync(code, dto);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{code}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [EndpointSummary("Удалить отправителя")]
    [EndpointDescription("Удаляет отправителя по его строковому коду")]
    public async Task<IActionResult> Delete(string code)
    {
        var success = await _service.DeleteAsync(code);
        return success ? NoContent() : NotFound();
    }
}

