using Application.DTOs.CustomDTOs;
using Domain.Entities;

namespace Application.Mappings.Transforms.Demandantes
{
    public static class DemandantesTransform
    {
        public static readonly Func<Demandante, DemandanteProfileDto> DemandanteEntityToDemandanteProfile = (item) =>
        {
            var profile = new DemandanteProfileDto
            {
                UsuarioId = item.UsuarioId,
                FechaNacimiento = item.FechaNacimiento,
                Movil = item.Movil,
                Perfil = item.Perfil,
                Nombre = item.Usuario.Nombre,
                Email = item.Usuario.Email,

                NivelEducativo = new DemandateNivelEducativoDto
                {
                    Id = item.NivelEducativoId,
                    Descripcion = item.NivelEducativo.Descripcion,
                },

                ExperienciaLaboral = item.ExperienciaLaboral?
                .OrderByDescending(x => x.FechaInicio)
                .Select(experiencia => new DemandanteExperienciaLaboralDto
                {
                    Id = experiencia.Id,
                    JefeDirecto = experiencia.JefeDirecto,
                    TelefonoContacto = experiencia.TelefonoContacto,
                    DescripcionLabor = experiencia.DescripcionLabol,
                    FechaInicio = experiencia.FechaInicio,
                    FechaFin = experiencia.FechaFin
                }).ToList()
            };


            return profile;
        };

    }
}
