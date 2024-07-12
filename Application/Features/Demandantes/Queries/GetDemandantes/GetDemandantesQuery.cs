using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Demandantes.Queries.GetDemandantes
{
    public class GetDemandantesQuery: IRequest<BaseWrapperResponse<List<DemandanteDto>>>
    {
    }
}
