using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Emparejamientos.Commands.Create
{
    public class CreateEmparejamientoCommand : IRequest<BaseWrapperResponse<VacanteDto>>
    {
        public long VacanteId { get; set; }
        public long DemandanteId { get; set; }
    }
}
