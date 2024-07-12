using Domain.Entities.Common;

namespace Domain.Entities;

public partial class Usuario : BaseEntity
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int TipoUsuarioId { get; set; }

    public virtual Demandante? Demandante { get; set; }

    public virtual Empleador? Empleador { get; set; }

    public virtual TipoUsuario TipoUsuario { get; set; } = null!;
}
