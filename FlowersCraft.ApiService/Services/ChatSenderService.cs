using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class ChatSenderService : IChatSenderService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public ChatSenderService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<ChatSenderDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.ChatSenders
            .Include(x => x.ChatMessages)
            .ProjectToType<ChatSenderDto>()
            .ToListAsync();
    }

    public async Task<ChatSenderDto?> GetByCodeAsync(string code)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ChatSenders
            .Include(x => x.ChatMessages)
            .FirstOrDefaultAsync(x => x.Code == code);

        return entity?.Adapt<ChatSenderDto>();
    }

    public async Task<ChatSenderDto> CreateAsync(ChatSenderDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<ChatSender>();
        db.ChatSenders.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<ChatSenderDto>();
    }

    public async Task<bool> UpdateAsync(string code, ChatSenderDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ChatSenders.FindAsync(code);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string code)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ChatSenders.FindAsync(code);
        if (entity == null) return false;

        db.ChatSenders.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}
