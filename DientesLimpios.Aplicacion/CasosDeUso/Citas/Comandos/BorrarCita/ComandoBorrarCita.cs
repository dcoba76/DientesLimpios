using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.BorrarCita;

public class ComandoBorrarCita: IRequest
{
    public required Guid Id { get; set; }
}
