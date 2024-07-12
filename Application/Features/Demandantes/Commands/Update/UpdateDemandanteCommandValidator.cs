using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Demandantes.Commands.Update
{
    public class UpdateDemandanteCommandValidator: AbstractValidator<UpdateDemandanteCommand>
    {
        public UpdateDemandanteCommandValidator()
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
