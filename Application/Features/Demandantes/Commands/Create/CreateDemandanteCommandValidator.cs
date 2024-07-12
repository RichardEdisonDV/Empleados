using FluentValidation;

namespace Application.Features.Demandantes.Commands.Create
{
    public class CreateDemandanteCommandValidator : AbstractValidator<CreateDemandanteCommand>
    {
        public CreateDemandanteCommandValidator()
        {
            RuleFor(x => x.UsuarioId)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío");

            RuleFor(x => x.Movil)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.NivelEducativoId)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío");

            RuleFor(x => x.Perfil)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");
        }
    }
}
