namespace Application.DTOs;

public partial class LocalizacionDto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    //public virtual ICollection<EmpleadorDto> Empleador { get; set; } = new List<EmpleadorDto>();
}
