using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.EnviarRecordatorioCita;

public class CasoDeUsoComandoEnviarRecordatorioCita : IRequestHandler<ComandoEnviarRecordatorioCita>
{
    private readonly IRepositorioCitas _repositorioCitas;
    private readonly IServicioNotificaciones _servicioNotificaciones;

    public CasoDeUsoComandoEnviarRecordatorioCita(IRepositorioCitas repositorioCitas,
        IServicioNotificaciones servicioNotificaciones)
    {
        this._repositorioCitas = repositorioCitas;
        this._servicioNotificaciones = servicioNotificaciones;
    }
    public async Task Handle(ComandoEnviarRecordatorioCita request)
    {
        var mañana = DateTime.UtcNow.Date.AddDays(1);
        var fechaInicio= mañana;
        var fechaFin = mañana.AddDays(1);
        var filtro = new FiltroCitasDTO
        {
            Inicio = fechaInicio,
            Fin = fechaFin,
            EstadoCita = Dominio.Enums.EstadoCita.Programada
        };
        
        var citas = await _repositorioCitas.ObtenerFiltrado(filtro);
        foreach (var cita in citas)
        {
            var citaDTO = cita.ADto();
            await _servicioNotificaciones.EnviarRecordatorioCita(citaDTO);
        }
    }
}
