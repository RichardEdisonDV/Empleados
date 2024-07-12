using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.Exceptions;
using Application.Specifications.Vacantes;
using Domain.Entities;
using MediatR;

namespace Application.Features.Emparejamientos.Commands.Delete
{
    public class DeleteEmparejamientoCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteEmparejamientoCommand>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteEmparejamientoCommand request, CancellationToken cancellationToken)
        {
            var vacante = await _unitOfWork.Repository<Vacante>().SingleOrDefaultAsync(
                new VacanteByIdSpecification(request.VacanteId)
                , cancellationToken)
                ?? throw new NotFoundException(nameof(Vacante), request.VacanteId);

            var demandante = await _unitOfWork.Repository<Demandante>().GetByIdAsync(request.DemandanteId, cancellationToken)
                ?? throw new NotFoundException(nameof(Demandante), request.DemandanteId);

            //vacante.Demandante = vacante.Demandante.Where(x => x.UsuarioId != demandante.UsuarioId).ToList();

            ////await _unitOfWork.Repository<Vacante>().UpdateAsync(vacante, cancellationToken);

            var deleteSql = $"DELETE FROM dbo.EMPAREJAMIENTO WHERE VACANTE_ID='{request.VacanteId}' AND DEMANDANTE_ID='{request.DemandanteId}';";
            await _unitOfWork.ExecuteSql(deleteSql);
        }
    }
}
