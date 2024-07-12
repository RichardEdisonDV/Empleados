using Domain.Entities.Common;

namespace Domain.Entities;

public partial class ExperienciaLaboral : BaseEntity
{
    public long Id { get; set; }

    public long DemandanteId { get; set; }

    public string JefeDirecto { get; set; } = null!;

    public string TelefonoContacto { get; set; } = null!;

    public string DescripcionLabol { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public virtual Demandante Demandante { get; set; } = null!;
}
