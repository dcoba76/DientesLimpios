using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerDetalleDentista;

public class ConsultaObtenerDetalleDentista: IRequest<DentistaDetalleDTO>
{
    public required Guid Id { get; set; }
}
