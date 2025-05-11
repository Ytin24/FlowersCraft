using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class ProductService : IProductService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public ProductService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Products
            .Include(p => p.Category)
            .ProjectToType<ProductDto>()
            .ToListAsync();
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var product = await db.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product?.Adapt<ProductDto>();
    }

    public async Task<ProductDto> CreateAsync(ProductDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<Product>();
        db.Products.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<ProductDto>();
    }

    public async Task<bool> UpdateAsync(int id, ProductDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Products.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.Products.FindAsync(id);
        if (entity == null) return false;

        db.Products.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

