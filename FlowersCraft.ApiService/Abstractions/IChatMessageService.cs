using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IChatMessageService
{
    Task<List<ChatMessageDto>> GetAllAsync();
    Task<ChatMessageDto?> GetByIdAsync(int id);
    Task<ChatMessageDto> CreateAsync(ChatMessageDto dto);
    Task<bool> UpdateAsync(int id, ChatMessageDto dto);
    Task<bool> DeleteAsync(int id);
}

