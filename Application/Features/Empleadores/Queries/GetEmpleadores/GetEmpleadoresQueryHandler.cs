using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Empleadores.Queries.GetEmpleadores
{
    public class GetEmpleadoresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetEmpleadoresQuery, BaseWrapperResponse<List<EmpleadorDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<List<EmpleadorDto>>> Handle(GetEmpleadoresQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<Empleador>().ListAsync(cancellationToken);
            var mappedResponse = _mapper.Map<List<EmpleadorDto>>(response);
            return new WrapperResponse<List<EmpleadorDto>>(mappedResponse);
        }
    }
}
