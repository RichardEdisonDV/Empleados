using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Vacantes.Commands.Update
{
    public class UpdateVacanteCommand: IRequest<BaseWrapperResponse<VacanteDto>>
    {
        public long Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Titulo { get; set; } = null!;
        public string Requisitos { get; set; } = null!;
    }
}
