using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Empleadores.Queries.GetEmpleadores
{
    public class GetEmpleadoresQuery:IRequest<BaseWrapperResponse<List<EmpleadorDto>>>
    {
    }
}
