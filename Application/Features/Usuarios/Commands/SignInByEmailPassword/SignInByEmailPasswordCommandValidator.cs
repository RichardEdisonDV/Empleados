using FluentValidation;

namespace Application.Features.Usuarios.Commands.SignInByEmailPassword
{
    public class SignInByEmailPasswordCommandValidator:AbstractValidator<SignInByEmailPasswordCommand>
    {
        public SignInByEmailPasswordCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .EmailAddress().WithMessage("{PropertyName} debe ser un email válido.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MinimumLength(6).WithMessage("{PropertyName} debe tener al menos 6 caracteres.");
        }
    }
}
