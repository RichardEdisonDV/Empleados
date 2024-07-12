using Application.DTOs;
using Application.Models.Auth;
using Domain.Entities;

namespace Application.Contracts.Services.AuthServices
{
    public interface IUserManagerService
    {
        public Task<Usuario?> GetUserByIdAsync(long id);
        public Task<Usuario?> GetUserByEmailAsync(string email);
        public Task<Usuario?> RegisterUserAsync(Usuario user);
        public Task<SignInResult> SignInByEmailPassword(Usuario user);
    }
}
