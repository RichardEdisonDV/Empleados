namespace Application.DTOs;

public partial class DemandanteDto
{
    public long UsuarioId { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Movil { get; set; } = null!;

    public int NivelEducativoId { get; set; }

    public string Perfil { get; set; } = null!;

    //public virtual ICollection<ExperienciaLaboralDto> ExperienciaLaboral { get; set; } = new List<ExperienciaLaboralDto>();

    //public virtual NivelEducativoDto NivelEducativo { get; set; } = null!;

    //public virtual UsuarioDto Usuario { get; set; } = null!;

    //public virtual ICollection<VacanteDto> Vacante { get; set; } = new List<VacanteDto>();
}
