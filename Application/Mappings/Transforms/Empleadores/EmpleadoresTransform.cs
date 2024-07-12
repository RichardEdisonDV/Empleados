using Application.DTOs.CustomDTOs;
using Domain.Entities;

namespace Application.Mappings.Transforms.Empleadores
{
    public static class EmpleadoresTransform
    {
        public static readonly Func<Empleador, EmpleadorProfileDto> EmpleadorEntityToEmpleadorProfile = (item) =>
        {
            var profile = new EmpleadorProfileDto
            {
                UsuarioId = item.UsuarioId,
                Nombre = item.Usuario.Nombre,
                Email = item.Usuario.Email,
                CantidadEmpleados = item.CantidadEmpleados,
                Perfil = item.Perfil,

                Industria = new EmpleadorIndustriaDto
                {
                    Id = item.IndustriaId,
                    Descripcion = item.Industria.Descripcion,
                },

                Localizacion = new EmpleadorLocalizacionDto
                {
                    Id = item.LocalizacionId,
                    Descripcion = item.Localizacion.Descripcion,
                    Direccion = item.Localizacion.Direccion,
                    Ubicacion = item.Localizacion.Ubicacion,
                },

                Vacante = item.Vacante?
                .OrderByDescending(x => x.FechaCreacion)
                .Select(vacante => new EmpleadorVacanteDto
                {
                    Id = vacante.Id,
                    EmpleadorId = vacante.EmpleadorId,
                    FechaCreacion = vacante.FechaCreacion,
                    Descripcion = vacante.Descripcion,
                    Titulo = vacante.Titulo,
                    Requisitos = vacante.Requisitos
                }).ToList()
            };

            return profile;
        };
    }
}
