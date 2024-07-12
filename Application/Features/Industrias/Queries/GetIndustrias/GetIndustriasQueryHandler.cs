using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Industrias.Queries.GetIndustrias
{
    public class GetIndustriasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetIndustriasQuery, BaseWrapperResponse<List<IndustriaDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<List<IndustriaDto>>> Handle(GetIndustriasQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<Industria>().ListAsync(cancellationToken);
            var responseDto = _mapper.Map<List<IndustriaDto>>(response);
            return new WrapperResponse<List<IndustriaDto>>(responseDto);
        }
    }
}
