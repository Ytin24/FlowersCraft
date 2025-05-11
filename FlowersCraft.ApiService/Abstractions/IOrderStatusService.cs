using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IOrderStatusService
{
    Task<List<OrderStatusDto>> GetAllAsync();
    Task<OrderStatusDto?> GetByCodeAsync(string code);
    Task<OrderStatusDto> CreateAsync(OrderStatusDto dto);
    Task<bool> UpdateAsync(string code, OrderStatusDto dto);
    Task<bool> DeleteAsync(string code);
}

