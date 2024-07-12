using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Vacantes
{
    public class VacanteByIdSpecification : SingleResultSpecification<Vacante>
    {
        public VacanteByIdSpecification(long id)
        {
            Query.Include(x => x.Empleador);
            Query.Include(x => x.Empleador.Usuario);
            Query.Include(x => x.Demandante);
            Query.Include("Demandante.Usuario");

            Query.Where(x => x.Id == id);
        }
    }
}
