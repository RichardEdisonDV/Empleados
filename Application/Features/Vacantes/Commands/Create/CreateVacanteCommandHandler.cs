using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Vacantes.Commands.Create
{
    public class CreateVacanteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateVacanteCommand, BaseWrapperResponse<VacanteDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<VacanteDto>> Handle(CreateVacanteCommand request, CancellationToken cancellationToken)
        {
            var toAdd = new Vacante
            {
                EmpleadorId = request.EmpleadorId,
                Descripcion = request.Descripcion,
                Titulo = request.Titulo,
                Requisitos = request.Requisitos,
                FechaCreacion = DateTime.Now,
            };

            var response = await _unitOfWork.Repository<Vacante>().AddAsync(toAdd, cancellationToken);
            //await _unitOfWork.Complete();

            var responseDto = _mapper.Map<VacanteDto>(response);
            return new WrapperResponse<VacanteDto>(responseDto);
        }
    }
}
