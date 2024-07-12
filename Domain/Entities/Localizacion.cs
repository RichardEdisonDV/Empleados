using Domain.Entities.Common;

namespace Domain.Entities;

public partial class Localizacion : BaseEntity
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public virtual ICollection<Empleador> Empleador { get; set; } = new List<Empleador>();
}
