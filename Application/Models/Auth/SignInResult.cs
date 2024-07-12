using Application.DTOs;
using Application.Statics.Enums;
using Domain.Entities;

namespace Application.Models.Auth
{
    public class SignInResult
    {
        public Usuario? Usuario { get; set; }
        public SignInState State { get; set; }
    }
}
