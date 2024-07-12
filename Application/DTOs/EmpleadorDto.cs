namespace Application.DTOs;

public partial class EmpleadorDto
{
    public long UsuarioId { get; set; }

    public int LocalizacionId { get; set; }

    public int IndustriaId { get; set; }

    public int CantidadEmpleados { get; set; }

    public string Perfil { get; set; } = null!;

    //public virtual IndustriaDto Industria { get; set; } = null!;

    //public virtual LocalizacionDto Localizacion { get; set; } = null!;

    //public virtual UsuarioDto Usuario { get; set; } = null!;

    //public virtual ICollection<VacanteDto> Vacante { get; set; } = new List<VacanteDto>();
}
