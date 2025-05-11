using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IOrderService
{
    Task<List<OrderDto>> GetAllAsync();
    Task<OrderDto?> GetByIdAsync(int id);
    Task<OrderDto> CreateAsync(OrderDto dto);
    Task<bool> UpdateAsync(int id, OrderDto dto);
    Task<bool> DeleteAsync(int id);
}

