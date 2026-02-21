using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;

public class ComandoCrearCita: IRequest<Guid>
{
    public required Guid PacienteId { get; set; }
    public required Guid DentistaId { get; set; }
    public required Guid ConsultorioId { get; set; }
    public required DateTime Inicio { get; set; }
    public required DateTime Fin { get; set; }
}
