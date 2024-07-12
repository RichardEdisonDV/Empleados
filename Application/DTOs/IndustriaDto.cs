namespace Application.DTOs;

public partial class IndustriaDto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    //public virtual ICollection<EmpleadorDto> Empleador { get; set; } = new List<EmpleadorDto>();
}
