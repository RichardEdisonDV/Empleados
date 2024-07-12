using FluentValidation;

namespace Application.Features.Emparejamientos.Commands.Create
{
    public class CreateEmparejamientoCommandValidator : AbstractValidator<CreateEmparejamientoCommand>
    {
        public CreateEmparejamientoCommandValidator()
        {
            RuleFor(p => p.VacanteId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0.");

            RuleFor(p => p.DemandanteId)
                .NotEmpty().WithMessage("{PropertyName} es requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0.");
        }
    }
}
