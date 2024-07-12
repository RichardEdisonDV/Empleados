using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vacantes.Commands.Delete
{
    public class DeleteVacanteCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteVacanteCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteVacanteCommand request, CancellationToken cancellationToken)
        {
            var toDelete = await _unitOfWork.Repository<Vacante>().GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Vacante), request.Id);
            await _unitOfWork.Repository<Vacante>().DeleteAsync(toDelete, cancellationToken);

        }
    }
}
