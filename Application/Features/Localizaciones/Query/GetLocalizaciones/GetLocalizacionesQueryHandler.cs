using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Localizaciones.Query.GetLocalizaciones
{
    public class GetLocalizacionesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetLocalizacionesQuery, BaseWrapperResponse<List<LocalizacionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<List<LocalizacionDto>>> Handle(GetLocalizacionesQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<Localizacion>().ListAsync(cancellationToken);
            var responseDto = _mapper.Map<List<LocalizacionDto>>(response);
            return new WrapperResponse<List<LocalizacionDto>>(responseDto);
        }
    }
}
