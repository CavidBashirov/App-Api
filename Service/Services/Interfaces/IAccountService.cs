using Service.DTOs.Account;
using Service.Helpers.Responses;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateRoleAsync();
        List<string> GetAllRoles();
        List<UserDto> GetAllUsers();
        Task<RegisterResponse> SignUpAsync(RegisterDto request);
        Task<LoginResponse> SignInAsync(LoginDto request);
        Task<BaseResponse> AddRoleToUserAsync(UserRoleDto request);
    }
}
