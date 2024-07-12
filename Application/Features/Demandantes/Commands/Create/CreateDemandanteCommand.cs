using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Demandantes.Commands.Create
{
    public class CreateDemandanteCommand : IRequest<BaseWrapperResponse<DemandanteDto>>
    {
        public long UsuarioId { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Movil { get; set; } = null!;
        public int NivelEducativoId { get; set; }
        public string Perfil { get; set; } = null!;
    }
}
