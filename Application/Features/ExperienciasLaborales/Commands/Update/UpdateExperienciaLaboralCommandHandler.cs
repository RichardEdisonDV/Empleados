using Application.Contracts.Persistence.Common.UnitOfWork;
using Application.DTOs;
using Application.Exceptions;
using Application.Wrappers;
using Application.Wrappers.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExperienciasLaborales.Commands.Update
{
    public class UpdateExperienciaLaboralCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateExperienciaLaboralCommand, BaseWrapperResponse<ExperienciaLaboralDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseWrapperResponse<ExperienciaLaboralDto>> Handle(UpdateExperienciaLaboralCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = await _unitOfWork.Repository<ExperienciaLaboral>().GetByIdAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(ExperienciaLaboral), request.Id);

            toUpdate.JefeDirecto = request.JefeDirecto;
            toUpdate.TelefonoContacto = request.TelefonoContacto;
            toUpdate.DescripcionLabol = request.DescripcionLabor;
            toUpdate.FechaInicio = request.FechaInicio;
            toUpdate.FechaFin = request.FechaFin;

            await _unitOfWork.Repository<ExperienciaLaboral>().UpdateAsync(toUpdate, cancellationToken);

            var response = await _unitOfWork.Repository<ExperienciaLaboral>().GetByIdAsync(request.Id, cancellationToken);
            var responseDto = _mapper.Map<ExperienciaLaboralDto>(response);
            return new WrapperResponse<ExperienciaLaboralDto>(responseDto);

        }
    }
}
