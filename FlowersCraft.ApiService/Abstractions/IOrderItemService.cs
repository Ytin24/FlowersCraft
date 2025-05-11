using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IOrderItemService
{
    Task<List<OrderItemDto>> GetAllAsync();
    Task<OrderItemDto?> GetByIdAsync(int id);
    Task<OrderItemDto> CreateAsync(OrderItemDto dto);
    Task<bool> UpdateAsync(int id, OrderItemDto dto);
    Task<bool> DeleteAsync(int id);
}
