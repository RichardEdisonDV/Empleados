namespace Application.DTOs.CustomDTOs
{
    public class DemandanteProfileDto
    {
        public long UsuarioId { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string Movil { get; set; } = string.Empty;
        public string Perfil { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public DemandateNivelEducativoDto? NivelEducativo { get; set; }
        public List<DemandanteExperienciaLaboralDto>? ExperienciaLaboral { get; set; } = [];

    }

    public class DemandateNivelEducativoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }

    public class DemandanteExperienciaLaboralDto
    {
        public long Id { get; set; }
        public string JefeDirecto { get; set; } = string.Empty;
        public string TelefonoContacto { get; set; } = string.Empty;
        public string DescripcionLabor { get; set; } = string.Empty;
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
    }
}
