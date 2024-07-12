using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.NivelesEducativos.Queries.GetNivelesEducativos
{
    public class GetNivelesEducativosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetNivelesEducativosQuery, BaseWrapperResponse<List<NivelEducativoDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;


        public async Task<BaseWrapperResponse<List<NivelEducativoDto>>> Handle(GetNivelesEducativosQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<NivelEducativo>().ListAsync(cancellationToken);
            var responseDto = _mapper.Map<List<NivelEducativoDto>>(response);
            return new WrapperResponse<List<NivelEducativoDto>>(responseDto);
        }
    }
}
