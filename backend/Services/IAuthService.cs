using backend.Models;

namespace backend.Services
{
    public interface IAuthService
    {
        Task<bool> Login(Login user);
        Task<bool> Register(Login user);
        Task<bool> AssignRole(string email, string role);
        Task<bool> RemoveRole(string email, string role);
        Task<string> GenerateTokenString(Login user);
    }
}