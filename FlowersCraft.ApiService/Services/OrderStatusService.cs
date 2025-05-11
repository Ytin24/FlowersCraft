using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class OrderStatusService : IOrderStatusService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public OrderStatusService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<OrderStatusDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.OrderStatuses
            .Include(x => x.Orders)
            .ProjectToType<OrderStatusDto>()
            .ToListAsync();
    }

    public async Task<OrderStatusDto?> GetByCodeAsync(string code)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.OrderStatuses
            .Include(x => x.Orders)
            .FirstOrDefaultAsync(x => x.Code == code);

        return entity?.Adapt<OrderStatusDto>();
    }

    public async Task<OrderStatusDto> CreateAsync(OrderStatusDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<OrderStatus>();
        db.OrderStatuses.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<OrderStatusDto>();
    }

    public async Task<bool> UpdateAsync(string code, OrderStatusDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.OrderStatuses.FindAsync(code);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(string code)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.OrderStatuses.FindAsync(code);
        if (entity == null) return false;

        db.OrderStatuses.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

