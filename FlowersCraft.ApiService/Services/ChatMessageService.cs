using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class ChatMessageService : IChatMessageService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public ChatMessageService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<ChatMessageDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.ChatMessages
            .Include(m => m.User)
            .Include(m => m.SenderNavigation)
            .ProjectToType<ChatMessageDto>()
            .ToListAsync();
    }

    public async Task<ChatMessageDto?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var msg = await db.ChatMessages
            .Include(m => m.User)
            .Include(m => m.SenderNavigation)
            .FirstOrDefaultAsync(m => m.Id == id);

        return msg?.Adapt<ChatMessageDto>();
    }

    public async Task<ChatMessageDto> CreateAsync(ChatMessageDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<ChatMessage>();
        db.ChatMessages.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<ChatMessageDto>();
    }

    public async Task<bool> UpdateAsync(int id, ChatMessageDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ChatMessages.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ChatMessages.FindAsync(id);
        if (entity == null) return false;

        db.ChatMessages.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

