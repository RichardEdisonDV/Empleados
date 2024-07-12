namespace Application.DTOs.CustomDTOs
{
    public class VacanteInfoDto
    {
        public long Id { get; set; }
        public long EmpleadorId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
        public virtual EmpleadorProfileDto? Empleador { get; set; }
        public virtual List<DemandanteProfileDto>? Demandante { get; set; } = [];
    }
}
