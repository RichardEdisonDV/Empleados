using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Exceptions;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vacantes.Commands.Update
{
    public class UpdateVacanteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<UpdateVacanteCommand, BaseWrapperResponse<VacanteDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<VacanteDto>> Handle(UpdateVacanteCommand request, CancellationToken cancellationToken)
        {

            var toUpdate = await _unitOfWork.Repository<Vacante>().GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Vacante), request.Id);
            toUpdate.Titulo = request.Titulo;
            toUpdate.Descripcion = request.Descripcion;
            toUpdate.Requisitos = request.Requisitos;

            await _unitOfWork.Repository<Vacante>().UpdateAsync(toUpdate, cancellationToken);

            var responseDto = _mapper.Map<VacanteDto>(toUpdate);
            return new WrapperResponse<VacanteDto>(responseDto);
        }
    }
}
