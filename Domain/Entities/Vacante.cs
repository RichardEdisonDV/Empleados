using Domain.Entities.Common;

namespace Domain.Entities;

public partial class Vacante : BaseEntity
{
    public long Id { get; set; }

    public long EmpleadorId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string Requisitos { get; set; } = null!;

    public virtual Empleador Empleador { get; set; } = null!;

    public virtual ICollection<Demandante> Demandante { get; set; } = new List<Demandante>();
}
