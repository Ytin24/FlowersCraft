using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class UserService : IUserService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public UserService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Users
            .ProjectToType<UserDto>()
            .ToListAsync();
    }

    public async Task<UserDto?> GetByIdAsync(long id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var user = await db.Users.FindAsync(id);
        return user?.Adapt<UserDto>();
    }

    public async Task<UserDto> CreateAsync(UserDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<User>();
        db.Users.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<UserDto>();
    }

    public async Task<bool> UpdateAsync(long id, UserDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Users.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Users.FindAsync(id);
        if (entity == null) return false;

        db.Users.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

