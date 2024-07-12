using Application.DTOs;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications.Usuarios
{
    public class SignInByEmailPasswordSpecification : SingleResultSpecification<Usuario>
    {
        public SignInByEmailPasswordSpecification(string email, string password)
        {
            Query.Where(u => u.Email.ToUpper() == email.ToUpper() && u.Password == password);
        }
    }
}
