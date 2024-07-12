using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs.CustomDTOs;
using Application.Specifications.Demandantes;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demandantes.Queries.GetDemandanteById
{
    public class GetDemandanteByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetDemandanteByIdQuery, BaseWrapperResponse<DemandanteProfileDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<DemandanteProfileDto>> Handle(GetDemandanteByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new DemandanteFilterSpecification(id: request.Id);
            var response = await _unitOfWork.Repository<Demandante>().FirstOrDefaultAsync(spec, cancellationToken);
            var responseDto = _mapper.Map<DemandanteProfileDto>(response);
            return new WrapperResponse<DemandanteProfileDto>(responseDto);
        }
    }
}
