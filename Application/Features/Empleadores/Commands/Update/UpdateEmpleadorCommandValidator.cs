using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Empleadores.Commands.Update
{
    public class UpdateEmpleadorCommandValidator: AbstractValidator<UpdateEmpleadorCommand>
    {
        public UpdateEmpleadorCommandValidator()
        {
            RuleFor(x => x.UsuarioId)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.LocalizacionId)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.IndustriaId)
                .GreaterThan(0).WithMessage("{PropertyName} no puede estar vacío.");

            RuleFor(x => x.CantidadEmpleados)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} no puede ser negativo.");

            RuleFor(p => p.Perfil)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío.")
                .NotNull().WithMessage("{PropertyName} no puede estar vacío.");
        }
    }
}
