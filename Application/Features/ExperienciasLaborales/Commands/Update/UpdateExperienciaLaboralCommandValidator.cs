using FluentValidation;

namespace Application.Features.ExperienciasLaborales.Commands.Update
{
    public class UpdateExperienciaLaboralCommandValidator : AbstractValidator<UpdateExperienciaLaboralCommand>
    {
        public UpdateExperienciaLaboralCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío");

            RuleFor(x => x.JefeDirecto)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.TelefonoContacto)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.FechaFin)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.")
                .GreaterThanOrEqualTo(x => x.FechaInicio);
        }
    }
}
