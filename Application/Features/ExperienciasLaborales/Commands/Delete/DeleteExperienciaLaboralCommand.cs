using MediatR;

namespace Application.Features.ExperienciasLaborales.Commands.Delete
{
    public class DeleteExperienciaLaboralCommand : IRequest
    {
        public long Id { get; set; }
    }
}
