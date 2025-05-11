using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public OrderItemService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<OrderItemDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.OrderItems
            .Include(x => x.Product)
            .Include(x => x.Order)
            .ProjectToType<OrderItemDto>()
            .ToListAsync();
    }

    public async Task<OrderItemDto?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var item = await db.OrderItems
            .Include(x => x.Product)
            .Include(x => x.Order)
            .FirstOrDefaultAsync(x => x.Id == id);

        return item?.Adapt<OrderItemDto>();
    }

    public async Task<OrderItemDto> CreateAsync(OrderItemDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<OrderItem>();
        db.OrderItems.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<OrderItemDto>();
    }

    public async Task<bool> UpdateAsync(int id, OrderItemDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.OrderItems.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.OrderItems.FindAsync(id);
        if (entity == null) return false;

        db.OrderItems.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

