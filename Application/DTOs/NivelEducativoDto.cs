namespace Application.DTOs;

public partial class NivelEducativoDto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    //public virtual ICollection<DemandanteDto> Demandante { get; set; } = new List<DemandanteDto>();
}
