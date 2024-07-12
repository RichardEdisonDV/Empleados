using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Vacantes
{
    public class VacanteFilterSpecification : Specification<Vacante>
    {
        public VacanteFilterSpecification(long? id = null
            , string? empleadorNombre = null
            , string? titulo = null
            , string? requisitos = null
            , string? industria = null
            , DateTime? fechaInicial = null)
        {
            Query.Include(x => x.Empleador);
            Query.Include(x => x.Empleador.Usuario);
            Query.Include(x => x.Empleador.Industria);
            Query.Include(x => x.Empleador.Localizacion);
            Query.Include(x => x.Demandante);
            Query.Include("Demandante.NivelEducativo");
            Query.Include("Demandante.ExperienciaLaboral");
            Query.Include("Demandante.Usuario");

            Query.Where(x => (!id.HasValue || x.Id == id)
            && (string.IsNullOrEmpty(empleadorNombre) || x.Empleador.Usuario.Nombre.ToUpper().Contains(empleadorNombre.ToUpper()))
            && (string.IsNullOrEmpty(titulo) || x.Titulo.ToUpper().Contains(titulo.ToUpper()))
            && (string.IsNullOrEmpty(requisitos) || x.Requisitos.ToUpper().Contains(requisitos.ToUpper()))
            && (string.IsNullOrEmpty(industria) || x.Empleador.Industria.Descripcion.ToUpper().Contains(industria.ToUpper()))
            && (!fechaInicial.HasValue || x.FechaCreacion >= fechaInicial.Value.Date)
            );
        }
    }
}
