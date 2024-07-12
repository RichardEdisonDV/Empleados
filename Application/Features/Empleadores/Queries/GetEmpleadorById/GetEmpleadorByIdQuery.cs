using Application.DTOs;
using Application.DTOs.CustomDTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Empleadores.Queries.GetEmpleadorById
{
    public class GetEmpleadorByIdQuery : IRequest<BaseWrapperResponse<EmpleadorProfileDto>>
    {
        public long Id { get; set; }
    }
}
