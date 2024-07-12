namespace Application.DTOs.CustomDTOs
{
    public class EmpleadorProfileDto
    {
        public long UsuarioId { get; set; }
        public int CantidadEmpleados { get; set; }
        public string Perfil { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual EmpleadorIndustriaDto? Industria { get; set; }
        public virtual EmpleadorLocalizacionDto? Localizacion { get; set; }
        public virtual List<EmpleadorVacanteDto>? Vacante { get; set; } = [];
    }

    public class EmpleadorIndustriaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }

    public class EmpleadorLocalizacionDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
    }

    public class EmpleadorVacanteDto
    {
        public long Id { get; set; }
        public long EmpleadorId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
    }
}
