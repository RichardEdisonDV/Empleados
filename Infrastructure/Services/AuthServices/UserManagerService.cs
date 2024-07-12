using Application.Attributes.Services;
using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.Contracts.Services.AuthServices;
using Application.Contracts.Services.EncryptionService;
using Application.Models.Auth;
using Application.Specifications.Usuarios;
using Application.Statics.Enums;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services.AuthServices
{
    [RegisterService(ServiceLifetime.Scoped)]
    public class UserManagerService(IUnitOfWork unitOfWork, IEncryptionService encryptionService) : IUserManagerService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IEncryptionService _encryptionService = encryptionService;

        public async Task<Usuario?> GetUserByEmailAsync(string email)
        {
            var spec = new UsuarioByEmailSpecification(email);
            var response = await _unitOfWork.Repository<Usuario>().SingleOrDefaultAsync(spec);
            return response;
        }

        public async Task<Usuario?> GetUserByIdAsync(long id)
        {
            var response = await _unitOfWork.Repository<Usuario>().GetByIdAsync(id);
            return response;
        }

        public async Task<Usuario?> RegisterUserAsync(Usuario user)
        {
            user.Password = _encryptionService.Encrypt(user.Password);
            var response = await _unitOfWork.Repository<Usuario>().AddAsync(user);
            return response;
        }

        public async Task<SignInResult> SignInByEmailPassword(Usuario user)
        {
            var password = _encryptionService.Encrypt(user.Password);
            var spec = new SignInByEmailPasswordSpecification(user.Email, password);
            var response = await _unitOfWork.Repository<Usuario>().SingleOrDefaultAsync(spec);
            return new SignInResult
            {
                Usuario = response,
                State = response == null ? SignInState.BadCredentials : SignInState.Success
            };

        }
    }
}
