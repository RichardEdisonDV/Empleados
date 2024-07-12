using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Demandantes
{
    public class DemandanteFilterSpecification : Specification<Demandante>
    {
        public DemandanteFilterSpecification(long? id = null, string? nombre = null, string? email = null, string? nivelEducativo = null)
        {
            Query.Include(e => e.NivelEducativo);
            Query.Include(e => e.Usuario);
            Query.Include(e => e.Usuario.TipoUsuario);
            Query.Include(e => e.ExperienciaLaboral);
            Query.Include(e => e.Vacante);

            Query.Where(e => (!id.HasValue || e.UsuarioId == id)
            && (string.IsNullOrEmpty(nombre) || e.Usuario.Nombre.ToUpper().Contains(nombre.ToUpper()))
            && (string.IsNullOrEmpty(email) || e.Usuario.Email.ToUpper().Contains(email.ToUpper()))
            && (string.IsNullOrEmpty(nivelEducativo) || e.NivelEducativo.Descripcion.ToUpper().Contains(nivelEducativo.ToUpper()))
            );
        }
    }
}
