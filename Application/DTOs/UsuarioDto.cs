namespace Application.DTOs;

public partial class UsuarioDto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    //public string Password { get; set; } = null!;

    public int TipoUsuarioId { get; set; }

    //public virtual DemandanteDto? Demandante { get; set; }

    //public virtual EmpleadorDto? Empleador { get; set; }

    //public virtual TipoUsuarioDto TipoUsuario { get; set; } = null!;
}
