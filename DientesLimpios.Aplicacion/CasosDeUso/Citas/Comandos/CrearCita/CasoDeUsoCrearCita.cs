using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;

public class CasoDeUsoCrearCita: IRequestHandler<ComandoCrearCita, Guid>
{
    private readonly IRepositorioCitas _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;
    private readonly IServicioNotificaciones _servicioNotificaciones;

    public CasoDeUsoCrearCita(IRepositorioCitas repositorio, IUnidadDeTrabajo unidadDeTrabajo, IServicioNotificaciones servicioNotificaciones)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
        this._servicioNotificaciones = servicioNotificaciones;
    }

    public async Task<Guid> Handle(ComandoCrearCita request)
    {

        var citaSeSolapa = await _repositorio.ExisteCitaSolapada(request.DentistaId, request.Inicio, request.Fin);

        if(citaSeSolapa)
        {
            throw new ExcepcionDeValidacion("El dentista ya tiene una cita en ese horario");
        }

        var intervalo = new IntervaloDeTiempo(request.Inicio, request.Fin);
        var cita = new Cita(request.PacienteId, request.DentistaId, request.ConsultorioId, intervalo);

        Guid? id = null;
        try
        {
            var respuesta = await _repositorio.Agregar(cita);
            await _unidadDeTrabajo.Persistir();
            id = respuesta.Id;
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }

        var citaDB = await _repositorio.ObtenerPorId(id.Value);
        var notificacionDTO = citaDB!.ADto();
        await _servicioNotificaciones.EnviarConfirmacionCita(notificacionDTO);
        return id.Value;
    }
}
