using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IProductCategoryService
{
    Task<List<ProductCategoryDto>> GetAllAsync();
    Task<ProductCategoryDto?> GetByIdAsync(int id);
    Task<ProductCategoryDto> CreateAsync(ProductCategoryDto dto);
    Task<bool> UpdateAsync(int id, ProductCategoryDto dto);
    Task<bool> DeleteAsync(int id);
}

