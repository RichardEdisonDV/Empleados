using FluentValidation;

namespace Application.Features.ExperienciasLaborales.Commands.Delete
{
    public class DeleteExperienciaLaboralCommandValidator : AbstractValidator<DeleteExperienciaLaboralCommand>
    {
        public DeleteExperienciaLaboralCommandValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío");
        }
    }
}
