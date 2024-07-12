using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Empleadores.Commands.Create
{
    public class CreateEmpleadorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateEmpleadorCommand, BaseWrapperResponse<EmpleadorDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<EmpleadorDto>> Handle(CreateEmpleadorCommand request, CancellationToken cancellationToken)
        {
            var toAdd = new Empleador
            {
                UsuarioId = request.UsuarioId,
                LocalizacionId = request.LocalizacionId,
                IndustriaId = request.IndustriaId,
                CantidadEmpleados = request.CantidadEmpleados,
                Perfil = request.Perfil,
            };

            var response = await _unitOfWork.Repository<Empleador>().AddAsync(toAdd, cancellationToken);
            var responseDto = _mapper.Map<EmpleadorDto>(response);
            return new WrapperResponse<EmpleadorDto>(responseDto);
        }
    }
}
