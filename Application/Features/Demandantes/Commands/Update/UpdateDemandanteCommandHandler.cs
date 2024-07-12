using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Exceptions;
using Application.Specifications.Demandantes;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demandantes.Commands.Update
{
    public class UpdateDemandanteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<UpdateDemandanteCommand, BaseWrapperResponse<DemandanteDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<DemandanteDto>> Handle(UpdateDemandanteCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.Repository<Demandante>().GetByIdAsync(request.UsuarioId, cancellationToken)
                ?? throw new NotFoundException(nameof(Demandante), request.UsuarioId);

            toUpdate.FechaNacimiento = request.FechaNacimiento;
            toUpdate.Movil = request.Movil;
            toUpdate.NivelEducativoId = request.NivelEducativoId;
            toUpdate.Perfil = request.Perfil;

            await _unitOfWork.Repository<Demandante>().UpdateAsync(toUpdate, cancellationToken);

            var response = await _unitOfWork.Repository<Demandante>().FirstOrDefaultAsync(new DemandanteFilterSpecification(id: request.UsuarioId));
            var responseDto = _mapper.Map<DemandanteDto>(response);
            return new WrapperResponse<DemandanteDto>(responseDto);
        }
    }
}
