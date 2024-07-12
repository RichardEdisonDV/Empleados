using FluentValidation;

namespace Application.Features.Vacantes.Commands.Delete
{
    public class DeleteVacanteCommandValidator : AbstractValidator<DeleteVacanteCommand>
    {
        public DeleteVacanteCommandValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío");
        }
    }
}
