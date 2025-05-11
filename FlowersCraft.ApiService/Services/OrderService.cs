using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class OrderService : IOrderService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public OrderService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<OrderDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Orders
            .Include(x => x.OrderItems)
            .ProjectToType<OrderDto>()
            .ToListAsync();
    }

    public async Task<OrderDto?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Orders
            .Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity?.Adapt<OrderDto>();
    }

    public async Task<OrderDto> CreateAsync(OrderDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<Order>();
        db.Orders.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<OrderDto>();
    }

    public async Task<bool> UpdateAsync(int id, OrderDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Orders.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Orders.FindAsync(id);
        if (entity == null) return false;

        db.Orders.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

