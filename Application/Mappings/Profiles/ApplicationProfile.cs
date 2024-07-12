using Application.DTOs;
using Application.DTOs.CustomDTOs;
using Application.Mappings.Transforms.Demandantes;
using Application.Mappings.Transforms.Empleadores;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Demandante, DemandanteDto>();
            CreateMap<Empleador, EmpleadorDto>();
            CreateMap<ExperienciaLaboral, ExperienciaLaboralDto>();
            CreateMap<Industria, IndustriaDto>();
            CreateMap<Localizacion, LocalizacionDto>();
            CreateMap<NivelEducativo, NivelEducativoDto>();
            CreateMap<TipoUsuario, TipoUsuarioDto>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Vacante, VacanteDto>();

            #region CustomDTOs
            CreateMap<Demandante, DemandanteProfileDto>().ConvertUsing(f => DemandantesTransform.DemandanteEntityToDemandanteProfile(f));
            CreateMap<Empleador, EmpleadorProfileDto>().ConvertUsing(f => EmpleadoresTransform.EmpleadorEntityToEmpleadorProfile(f));
            CreateMap<Vacante, VacanteInfoDto>();
            #endregion
        }
    }
}
