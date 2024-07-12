using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Usuarios.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<BaseWrapperResponse<UsuarioDto>>
    {
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int TipoUsuarioId { get; set; }
    }
}
