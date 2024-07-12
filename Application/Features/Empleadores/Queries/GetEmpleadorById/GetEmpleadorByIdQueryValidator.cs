using FluentValidation;

namespace Application.Features.Empleadores.Queries.GetEmpleadorById
{
    public class GetEmpleadorByIdQueryValidator : AbstractValidator<GetEmpleadorByIdQuery>
    {
        public GetEmpleadorByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor que 0.");
        }
    }
}
