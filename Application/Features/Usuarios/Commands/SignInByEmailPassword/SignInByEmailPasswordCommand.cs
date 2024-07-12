using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Usuarios.Commands.SignInByEmailPassword
{
    public class SignInByEmailPasswordCommand : IRequest<BaseWrapperResponse<UsuarioDto>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
