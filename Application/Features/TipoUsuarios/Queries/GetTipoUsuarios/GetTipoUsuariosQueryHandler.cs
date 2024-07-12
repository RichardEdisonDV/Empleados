using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TipoUsuarios.Queries.GetTipoUsuarios
{
    public class GetTipoUsuariosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetTipoUsuariosQuery, BaseWrapperResponse<List<TipoUsuarioDto>>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<List<TipoUsuarioDto>>> Handle(GetTipoUsuariosQuery request, CancellationToken cancellationToken)
        {
            var response = await _unitOfWork.Repository<TipoUsuario>().ListAsync();
            var responseDto = _mapper.Map<List<TipoUsuarioDto>>(response);
            return new WrapperResponse<List<TipoUsuarioDto>>(responseDto);
        }
    }
}
