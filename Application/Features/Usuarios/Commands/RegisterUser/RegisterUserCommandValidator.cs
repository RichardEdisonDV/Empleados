using FluentValidation;

namespace Application.Features.Usuarios.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder los 100 caracteres.")
                .EmailAddress().WithMessage("{PropertyName} no es un email válido.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .MinimumLength(6).WithMessage("{PropertyName} debe tener al menos 6 caracteres.");

            RuleFor(p => p.TipoUsuarioId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0.");
        }
    }
}
