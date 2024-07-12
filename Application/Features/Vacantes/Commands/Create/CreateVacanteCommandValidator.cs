using FluentValidation;

namespace Application.Features.Vacantes.Commands.Create
{
    public class CreateVacanteCommandValidator : AbstractValidator<CreateVacanteCommand>
    {
        public CreateVacanteCommandValidator()
        {
            RuleFor(p => p.EmpleadorId)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío");

            RuleFor(p => p.Descripcion)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.Titulo)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(p => p.Requisitos)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");
        }
    }
}
