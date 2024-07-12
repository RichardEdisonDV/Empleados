using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.Empleadores.Commands.Update
{
    public class UpdateEmpleadorCommand : IRequest<BaseWrapperResponse<EmpleadorDto>>
    {
        public long UsuarioId { get; set; }
        public int LocalizacionId { get; set; }
        public int IndustriaId { get; set; }
        public int CantidadEmpleados { get; set; }
        public string Perfil { get; set; } = null!;
    }
}
