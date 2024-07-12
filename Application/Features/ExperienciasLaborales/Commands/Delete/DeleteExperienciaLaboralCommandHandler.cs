using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExperienciasLaborales.Commands.Delete
{
    public class DeleteExperienciaLaboralCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteExperienciaLaboralCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteExperienciaLaboralCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _unitOfWork.Repository<ExperienciaLaboral>().GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(ExperienciaLaboral), request.Id);
            await _unitOfWork.Repository<ExperienciaLaboral>().DeleteAsync(toDelete, cancellationToken);
        }
    }
}
