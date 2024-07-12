using MediatR;

namespace Application.Features.Emparejamientos.Commands.Delete
{
    public class DeleteEmparejamientoCommand : IRequest
    {
        public long VacanteId { get; set; }
        public long DemandanteId { get; set; }
    }
}
