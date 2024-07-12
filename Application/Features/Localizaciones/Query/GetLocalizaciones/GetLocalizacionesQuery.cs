using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Localizaciones.Query.GetLocalizaciones
{
    public class GetLocalizacionesQuery : IRequest<BaseWrapperResponse<List<LocalizacionDto>>>
    {
    }
}
