using Domain.Entities.Common;

namespace Domain.Entities;

public partial class Demandante : BaseEntity
{
    public long UsuarioId { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Movil { get; set; } = null!;

    public int NivelEducativoId { get; set; }

    public string Perfil { get; set; } = null!;

    public virtual ICollection<ExperienciaLaboral> ExperienciaLaboral { get; set; } = new List<ExperienciaLaboral>();

    public virtual NivelEducativo NivelEducativo { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Vacante> Vacante { get; set; } = new List<Vacante>();
}
