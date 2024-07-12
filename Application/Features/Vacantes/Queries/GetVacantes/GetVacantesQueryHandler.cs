using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs.CustomDTOs;
using Application.Specifications.Vacantes;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vacantes.Queries.GetVacantes
{
    public class GetVacantesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetVacantesQuery, BaseWrapperResponse<List<VacanteInfoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<List<VacanteInfoDto>>> Handle(GetVacantesQuery request, CancellationToken cancellationToken)
        {
            var spec = new VacanteFilterSpecification();
            var response = await _unitOfWork.Repository<Vacante>().ListAsync(spec, cancellationToken);
            var mappedResponse = _mapper.Map<List<VacanteInfoDto>>(response.OrderByDescending(x => x.FechaCreacion));
            return new WrapperResponse<List<VacanteInfoDto>>(mappedResponse);
        }
    }
}
