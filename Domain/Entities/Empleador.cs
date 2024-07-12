using Domain.Entities.Common;

namespace Domain.Entities;

public partial class Empleador : BaseEntity
{
    public long UsuarioId { get; set; }

    public int LocalizacionId { get; set; }

    public int IndustriaId { get; set; }

    public int CantidadEmpleados { get; set; }

    public string Perfil { get; set; } = null!;

    public virtual Industria Industria { get; set; } = null!;

    public virtual Localizacion Localizacion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Vacante> Vacante { get; set; } = new List<Vacante>();
}
