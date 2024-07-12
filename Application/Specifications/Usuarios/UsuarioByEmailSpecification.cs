using Application.DTOs;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Usuarios
{
    public class UsuarioByEmailSpecification: SingleResultSpecification<Usuario>
    {
        public UsuarioByEmailSpecification(string email)
        {
            Query.Where(u => u.Email == email);
        }
    }
}
