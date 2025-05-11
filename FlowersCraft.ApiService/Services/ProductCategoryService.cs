using FlowersCraft.ApiService.Abstractions;
using FlowersCraft.ApiService.Data;
using FlowersCraft.ApiService.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FlowersCraft.ApiService.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IDbContextFactory<FlowersCraftDbContext> _factory;

    public ProductCategoryService(IDbContextFactory<FlowersCraftDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<ProductCategoryDto>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.ProductCategories
            .Include(c => c.Products)
            .ProjectToType<ProductCategoryDto>()
            .ToListAsync();
    }

    public async Task<ProductCategoryDto?> GetByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ProductCategories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(x => x.Id == id);

        return entity?.Adapt<ProductCategoryDto>();
    }

    public async Task<ProductCategoryDto> CreateAsync(ProductCategoryDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = dto.Adapt<ProductCategory>();
        db.ProductCategories.Add(entity);
        await db.SaveChangesAsync();
        return entity.Adapt<ProductCategoryDto>();
    }

    public async Task<bool> UpdateAsync(int id, ProductCategoryDto dto)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ProductCategories.FindAsync(id);
        if (entity == null) return false;

        dto.Adapt(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var entity = await db.ProductCategories.FindAsync(id);
        if (entity == null) return false;

        db.ProductCategories.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }
}

