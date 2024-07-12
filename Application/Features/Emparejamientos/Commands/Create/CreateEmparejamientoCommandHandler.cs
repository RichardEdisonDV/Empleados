using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Exceptions;
using Application.Specifications.Vacantes;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Emparejamientos.Commands.Create
{
    public class CreateEmparejamientoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateEmparejamientoCommand, BaseWrapperResponse<VacanteDto>>
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<VacanteDto>> Handle(CreateEmparejamientoCommand request, CancellationToken cancellationToken)
        {
            var vacante = await _unitOfWork.Repository<Vacante>().GetByIdAsync(request.VacanteId, cancellationToken)
                ?? throw new NotFoundException(nameof(Vacante), request.VacanteId);

            var demandante = await _unitOfWork.Repository<Demandante>().GetByIdAsync(request.DemandanteId, cancellationToken)
                ?? throw new NotFoundException(nameof(Demandante), request.DemandanteId);

            vacante.Demandante.Add(demandante);
            await _unitOfWork.Repository<Vacante>().UpdateAsync(vacante, cancellationToken);

            var response = await _unitOfWork.Repository<Vacante>().FirstOrDefaultAsync(new VacanteFilterSpecification(id: request.VacanteId));
            var responseDto = _mapper.Map<VacanteDto>(response);
            return new WrapperResponse<VacanteDto>(responseDto);
        }
    }
}
