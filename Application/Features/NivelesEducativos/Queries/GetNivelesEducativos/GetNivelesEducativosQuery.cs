using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.NivelesEducativos.Queries.GetNivelesEducativos
{
    public class GetNivelesEducativosQuery : IRequest<BaseWrapperResponse<List<NivelEducativoDto>>>
    {
    }
}
