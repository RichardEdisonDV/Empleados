namespace Application.DTOs;

public partial class VacanteDto
{
    public long Id { get; set; }

    public long EmpleadorId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string Requisitos { get; set; } = null!;

    //public virtual EmpleadorDto Empleador { get; set; } = null!;

    //public virtual ICollection<DemandanteDto> Demandante { get; set; } = new List<DemandanteDto>();
}
