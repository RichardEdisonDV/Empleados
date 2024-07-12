using Domain.Entities.Common;

namespace Domain.Entities;

public partial class TipoUsuario : BaseEntity
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
