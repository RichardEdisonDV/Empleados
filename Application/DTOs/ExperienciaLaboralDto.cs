namespace Application.DTOs;

public partial class ExperienciaLaboralDto
{
    public long Id { get; set; }

    public long DemandanteId { get; set; }

    public string JefeDirecto { get; set; } = null!;

    public string TelefonoContacto { get; set; } = null!;

    public string DescripcionLabol { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    //public virtual DemandanteDto Demandante { get; set; } = null!;
}
