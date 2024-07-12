using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Demandantes.Queries.GetDemandantes
{
    public class GetDemandantesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetDemandantesQuery, BaseWrapperResponse<List<DemandanteDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<List<DemandanteDto>>> Handle(GetDemandantesQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<Demandante>().ListAsync();
            var responseDto = _mapper.Map<List<DemandanteDto>>(response);
            return new WrapperResponse<List<DemandanteDto>>(responseDto);
        }
    }
}
