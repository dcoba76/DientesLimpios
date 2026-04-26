using DientesLimpios.Dominio.Enums;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;

public class FiltroCitasDTO
{
    public int Pagina { get; set; } = 1;
    public int RegistrosPorPagina { get; set; } = 10;
    public Guid? PacienteId { get; set; }
    public Guid? DentistaId { get; set; }
    public Guid? ConsultorioId { get; set; }
    public EstadoCita? EstadoCita { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }
}
