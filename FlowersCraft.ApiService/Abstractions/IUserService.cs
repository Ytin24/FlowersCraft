using FlowersCraft.ApiService.Models;

namespace FlowersCraft.ApiService.Abstractions;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(long id);
    Task<UserDto> CreateAsync(UserDto dto);
    Task<bool> UpdateAsync(long id, UserDto dto);
    Task<bool> DeleteAsync(long id);
}
