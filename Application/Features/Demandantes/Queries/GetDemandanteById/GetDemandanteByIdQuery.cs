using Application.DTOs.CustomDTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Demandantes.Queries.GetDemandanteById
{
    public class GetDemandanteByIdQuery : IRequest<BaseWrapperResponse<DemandanteProfileDto>>
    {
        public long Id { get; set; }
    }
}
