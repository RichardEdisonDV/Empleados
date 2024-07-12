using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Exceptions;
using Application.Specifications.Empleadores;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Empleadores.Commands.Update
{
    public class UpdateEmpleadorCommandHandler : IRequestHandler<UpdateEmpleadorCommand, BaseWrapperResponse<EmpleadorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmpleadorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseWrapperResponse<EmpleadorDto>> Handle(UpdateEmpleadorCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.Repository<Empleador>().GetByIdAsync(request.UsuarioId, cancellationToken)
                ?? throw new NotFoundException(nameof(Empleador), request.UsuarioId);

            toUpdate.LocalizacionId = request.LocalizacionId;
            toUpdate.IndustriaId = request.IndustriaId;
            toUpdate.CantidadEmpleados = request.CantidadEmpleados;
            toUpdate.Perfil = request.Perfil;

            await _unitOfWork.Repository<Empleador>().UpdateAsync(toUpdate, cancellationToken);
            var response = await _unitOfWork.Repository<Empleador>().FirstOrDefaultAsync(
                new EmpleadorFilterSpecification(id: request.UsuarioId)
                , cancellationToken);
            var responseDto = _mapper.Map<EmpleadorDto>(response);
            return new WrapperResponse<EmpleadorDto>(responseDto);
        }
    }
}
