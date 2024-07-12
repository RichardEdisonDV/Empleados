namespace Application.DTOs;

public partial class TipoUsuarioDto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    //public virtual ICollection<UsuarioDto> Usuario { get; set; } = new List<UsuarioDto>();
}
