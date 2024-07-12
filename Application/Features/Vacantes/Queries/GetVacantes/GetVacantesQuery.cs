using Application.DTOs;
using Application.DTOs.CustomDTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Vacantes.Queries.GetVacantes
{
    public class GetVacantesQuery : IRequest<BaseWrapperResponse<List<VacanteInfoDto>>>
    {
    }
}
