using Application.Contracts.Services.AuthServices;
using Application.DTOs;
using Application.Exceptions;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Usuarios.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(IUserManagerService userManagerService, IMapper mapper) : IRequestHandler<RegisterUserCommand, BaseWrapperResponse<UsuarioDto>>
    {
        private readonly IUserManagerService _userManagerService = userManagerService;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<UsuarioDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _userManagerService.GetUserByEmailAsync(request.Email);

            if (usuario != null)
            {
                throw new RecordAlreadyExistException("El usuario ya se encuentra registrado");
            }

            var createdUser = await _userManagerService.RegisterUserAsync(new Usuario
            {
                Nombre = request.Nombre,
                Email = request.Email,
                Password = request.Password,
                TipoUsuarioId = request.TipoUsuarioId
            });

            var responseDto = _mapper.Map<UsuarioDto>(createdUser);
            return new WrapperResponse<UsuarioDto>(responseDto);

        }
    }
}
