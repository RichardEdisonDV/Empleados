using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Vacantes.Commands.Create
{
    public class CreateVacanteCommand : IRequest<BaseWrapperResponse<VacanteDto>>
    {
        public long EmpleadorId { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Requisitos { get; set; } = null!;
    }
}
