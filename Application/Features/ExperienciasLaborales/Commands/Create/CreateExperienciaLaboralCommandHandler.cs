using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExperienciasLaborales.Commands.Create
{
    public class CreateExperienciaLaboralCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
                : IRequestHandler<CreateExperienciaLaboralCommand, BaseWrapperResponse<ExperienciaLaboralDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<ExperienciaLaboralDto>> Handle(CreateExperienciaLaboralCommand request, CancellationToken cancellationToken)
        {
            var toAdd = new ExperienciaLaboral
            {
                DemandanteId = request.DemandanteId,
                JefeDirecto = request.JefeDirecto,
                TelefonoContacto = request.TelefonoContacto,
                DescripcionLabol = request.DescripcionLabor,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
            };

            var response = await _unitOfWork.Repository<ExperienciaLaboral>().AddAsync(toAdd, cancellationToken);
            var responseDto = _mapper.Map<ExperienciaLaboralDto>(response);
            return new WrapperResponse<ExperienciaLaboralDto>(responseDto);
        }
    }
}
