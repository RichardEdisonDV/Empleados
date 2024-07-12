using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Empleadores
{
    public class EmpleadorFilterSpecification : Specification<Empleador>
    {
        public EmpleadorFilterSpecification(long? id = null, string? nombre = null, string? email = null, string? industria = null)
        {
            Query.Include(e => e.Industria);
            Query.Include(e => e.Usuario);
            Query.Include(e => e.Usuario.TipoUsuario);
            Query.Include(e => e.Localizacion);
            Query.Include(e => e.Vacante);

            Query.Where(e => (!id.HasValue || e.UsuarioId == id)
            && (string.IsNullOrEmpty(nombre) || e.Usuario.Nombre.ToUpper().Contains(nombre.ToUpper()))
            && (string.IsNullOrEmpty(email) || e.Usuario.Email.ToUpper().Contains(email.ToUpper()))
            && (string.IsNullOrEmpty(industria) || e.Industria.Descripcion.ToUpper().Contains(industria.ToUpper()))
            );
        }
    }
}
