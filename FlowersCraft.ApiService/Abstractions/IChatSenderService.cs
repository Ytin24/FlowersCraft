using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IChatSenderService
{
    Task<List<ChatSenderDto>> GetAllAsync();
    Task<ChatSenderDto?> GetByCodeAsync(string code);
    Task<ChatSenderDto> CreateAsync(ChatSenderDto dto);
    Task<bool> UpdateAsync(string code, ChatSenderDto dto);
    Task<bool> DeleteAsync(string code);
}

