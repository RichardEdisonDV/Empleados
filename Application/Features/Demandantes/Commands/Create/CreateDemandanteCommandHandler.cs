using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Specifications.Demandantes;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demandantes.Commands.Create
{
    public class CreateDemandanteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateDemandanteCommand, BaseWrapperResponse<DemandanteDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<DemandanteDto>> Handle(CreateDemandanteCommand request, CancellationToken cancellationToken)
        {
            var toAdd = new Demandante
            {
                UsuarioId = request.UsuarioId,
                Movil = request.Movil,
                FechaNacimiento = request.FechaNacimiento,
                NivelEducativoId = request.NivelEducativoId,
                Perfil = request.Perfil
            };

            var entity = await _unitOfWork.Repository<Demandante>().AddAsync(toAdd, cancellationToken);

            var response = await _unitOfWork.Repository<Demandante>()
                .FirstOrDefaultAsync(new DemandanteFilterSpecification(id: entity.UsuarioId), cancellationToken);

            var responseDto = _mapper.Map<DemandanteDto>(response);
            return new WrapperResponse<DemandanteDto>(responseDto);
        }
    }
}
