﻿using Application.DTOs;
using Application.Wrappers.Common;
using MediatR;

namespace Application.Features.ExperienciasLaborales.Commands.Update
{
    public class UpdateExperienciaLaboralCommand : IRequest<BaseWrapperResponse<ExperienciaLaboralDto>>
    {
        public long Id { get; set; }

        public string JefeDirecto { get; set; } = null!;

        public string TelefonoContacto { get; set; } = null!;

        public string DescripcionLabor { get; set; } = null!;

        public DateOnly FechaInicio { get; set; }

        public DateOnly FechaFin { get; set; }
    }
}
