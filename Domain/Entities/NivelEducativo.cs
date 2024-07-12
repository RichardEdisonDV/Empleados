using Domain.Entities.Common;

namespace Domain.Entities;

public partial class NivelEducativo : BaseEntity
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Demandante> Demandante { get; set; } = new List<Demandante>();
}
