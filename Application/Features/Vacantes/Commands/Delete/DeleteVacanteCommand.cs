using MediatR;

namespace Application.Features.Vacantes.Commands.Delete
{
    public class DeleteVacanteCommand : IRequest
    {
        public long Id { get; set; }
    }
}
