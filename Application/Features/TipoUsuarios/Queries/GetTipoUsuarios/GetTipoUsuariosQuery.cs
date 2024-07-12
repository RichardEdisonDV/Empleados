using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.TipoUsuarios.Queries.GetTipoUsuarios
{
    public class GetTipoUsuariosQuery : IRequest<BaseWrapperResponse<List<TipoUsuarioDto>>>
    {
    }
}
