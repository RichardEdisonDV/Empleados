using FluentValidation;

namespace Application.Features.Demandantes.Queries.GetDemandanteById
{
    public class GetDemandanteByIdQueryValidator : AbstractValidator<GetDemandanteByIdQuery>
    {
        public GetDemandanteByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor que 0.");
        }
    }
}
