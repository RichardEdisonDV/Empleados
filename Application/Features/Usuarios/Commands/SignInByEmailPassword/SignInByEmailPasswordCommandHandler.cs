using Application.Contracts.Services.AuthServices;
using Application.DTOs;
using Application.Exceptions;
using Application.Statics.Enums;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Usuarios.Commands.SignInByEmailPassword
{
    public class SignInByEmailPasswordCommandHandler(IUserManagerService userManagerService, IMapper mapper) : IRequestHandler<SignInByEmailPasswordCommand, BaseWrapperResponse<UsuarioDto>>
    {
        private readonly IUserManagerService _userManagerService = userManagerService;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<UsuarioDto>> Handle(SignInByEmailPasswordCommand request, CancellationToken cancellationToken)
        {
            var userToSignIn = new Usuario
            {
                Email = request.Email,
                Password = request.Password
            };
            var response = await _userManagerService.SignInByEmailPassword(userToSignIn);

            switch (response.State)
            {
                case SignInState.Success:
                    var responseDto = _mapper.Map<UsuarioDto>(response.Usuario);
                    return new WrapperResponse<UsuarioDto>(responseDto);
                default:
                    throw new UnauthorizedException("Error al iniciar sesión");
            }
        }
    }
}
