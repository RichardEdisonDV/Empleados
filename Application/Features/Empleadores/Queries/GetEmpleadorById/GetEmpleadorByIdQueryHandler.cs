using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs.CustomDTOs;
using Application.Specifications.Empleadores;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Empleadores.Queries.GetEmpleadorById
{
    public class GetEmpleadorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetEmpleadorByIdQuery, BaseWrapperResponse<EmpleadorProfileDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<EmpleadorProfileDto>> Handle(GetEmpleadorByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new EmpleadorFilterSpecification(id: request.Id);
            var response = await _unitOfWork.Repository<Empleador>().FirstOrDefaultAsync(spec, cancellationToken);
            var responseDto = _mapper.Map<EmpleadorProfileDto>(response);
            return new WrapperResponse<EmpleadorProfileDto>(responseDto);
        }
    }
}
